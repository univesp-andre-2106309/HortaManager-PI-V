using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries.Handlers
{
    public interface IQueryHandler<T,J> where T : class where J : class
    {
        Task<T> Handle(J query);
    }
}
