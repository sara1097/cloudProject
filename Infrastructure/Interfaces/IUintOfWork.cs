using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUintOfWork : IDisposable
    {
       IbudgetRepository budgets { get; }
       IcategoryRepository categories { get; }
        Task<int> SaveChangesAsync();
    }
   
}
