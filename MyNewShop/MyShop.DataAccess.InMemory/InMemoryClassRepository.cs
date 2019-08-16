using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    // <T> object inherits BaseEntity Model 
    public class InMemoryClassRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryClassRepository()
        {
            // get the actual name of our class
            // constructor
            className = typeof(T).Name;

            items = cache[className] as List<T>;

            if(items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            //store our items in memory
           cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T itemToUpdate = items.Find(n => n.Id == t.Id);
            
            if(itemToUpdate != null)
            {
                itemToUpdate = t;
            }

            else
            {
                throw new Exception(className + " Not found");
            }
        }

        public T Find(string Id)
        {
            T t = items.Find(n => n.Id == Id);

            if(t != null)
            {
                return t;
            }

            else
            {
                throw new Exception(className + " Not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            T tToDelete = items.Find(n => n.Id == Id);

            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }

            else
            {
                throw new Exception(className + " not found");
            }

        }

    }
}

    

