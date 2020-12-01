using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.BlazorUI.Contracts
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Get(string url, int id);
        Task<IList<T>> Get(string url);
        Task<bool> Create(string url, T obj);
        Task<bool> Update(string url, T obj);
        Task<bool> Delete(string url, int id);
    }
}
