using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Commands.Handlers
{
    public interface ICommandHandler<T, J> where T : class where J : class
    {
        Task<T> Handle(J command);
    }
}
