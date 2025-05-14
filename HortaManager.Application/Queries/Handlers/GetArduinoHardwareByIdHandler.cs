using HortaManager.Domain.Models;
using HortaManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries.Handlers
{
    public class GetArduinoHardwareByIdHandler : IQueryHandler<ArduinoDevice, GetArduinoHardwareByIdQuery>
    {
        private readonly IRepository<ArduinoDevice> repository;

        public GetArduinoHardwareByIdHandler(IRepository<ArduinoDevice> repository)
        {
            this.repository = repository;
        }
        public async Task<ArduinoDevice> Handle(GetArduinoHardwareByIdQuery query)
        {

            List<ArduinoDevice> arduinoList = this.repository.GetQueryable().Where(x => 
                x.Code == query.Code && x.IsActive == true).ToList() ?? [];
            ArduinoDevice device = arduinoList.FirstOrDefault();
            return device;

        }
    }
}
