using System.Linq;
using MyShop.Core.Models;

namespace MyShop.Core.Contracts

{
    // created an IRepository and has all the methods/functions in the core project to reference this to different classes
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}