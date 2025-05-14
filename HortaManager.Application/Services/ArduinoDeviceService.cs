using HortaManager.Application.Queries.Handlers;
using HortaManager.Domain.Models;
using HortaManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Services
{
    public class ArduinoDeviceService : IArduinoDeviceService
    {
        private readonly IRepository<ArduinoDevice> arduinoRepository;
        private readonly IQueryMediator queryMediator;

        public ArduinoDeviceService(IRepository<ArduinoDevice> arduinoRepository, IQueryMediator queryMediator)
        {
            this.arduinoRepository = arduinoRepository;
            this.queryMediator = queryMediator;
        }

        public async Task<ArduinoDevice> getArduinoDevice(string code)
        {
            ArduinoDevice device = await this.queryMediator.GetArduinoHardwareByIdCaller().Handle(new Queries.GetArduinoHardwareByIdQuery
            {
                Code = code
            });
            return device;

        }

        public async Task<ArduinoDevice> InsertDevice(string code)
        {
            ArduinoDevice device = new ArduinoDevice
            {
                Code = code,
            };

            return await this.arduinoRepository.AddAsync(device);
        }

    }
}
