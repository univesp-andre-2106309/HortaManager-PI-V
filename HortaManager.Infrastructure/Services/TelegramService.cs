using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HortaManager.Infrastructure.Integrations
{
    public class TelegramService: ITelegramService
    {

        private readonly string _telegramAuthKey;
        private readonly string _telegramGroupId;
        private TelegramBotClient client;

        public TelegramService(IConfiguration config)
        {
            this._telegramAuthKey = config["Telegram:Key"] ?? "";
            this._telegramGroupId = config["Telegram:GroupId"] ?? "";
            this.client = new TelegramBotClient(this._telegramAuthKey);
        }


        public async Task SendTelegramAlert(string status, int soilHumidity, string arduinoIdentifier)
        {
            string message = $"🔔 *Alerta da Horta - {arduinoIdentifier}:*\n\n" +
                         $"✅ Foi identificado o status *{status}*\n" +
                         $"💧 O nível de umidade atual é de *{soilHumidity}%*\n" +
                         $"🚰 A irrigação foi {(soilHumidity < 70 ? "*Ativada*" : "*Desativada*")}";

            await client.SendMessage(
               chatId: _telegramGroupId,
               text: message,
               parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown
           );

            
        }
    }
}
