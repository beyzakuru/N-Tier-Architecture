using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Repositories
{
    // IGenericRepository'nin T tipinde olduğunun tanımlanması ve class'tan oluştuğunun ifade edilmesi
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        //Passenger.GetAll(x ==> x.FirstName == "Beyza").ToList();
        IQueryable<T> GetAll();

        // Passenger.Where(x ==> x.FirstName == "Beyza").ToList().OrderBy(); Veritabanına gider, sonra sıralama yapar.
        // Passenger.Where(x ==> x.FirstName == "Beyza").OrderBy(); Veritabanına gitmeden ön bellekten sıralama yapar.

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
