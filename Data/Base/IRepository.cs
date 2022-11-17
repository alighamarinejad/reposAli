using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Base
{
    public interface IRepository<T> where T :Models.Base.entity
    {
        void Insert(T entity);

        System.Threading.Tasks.Task InsertAsync(T entity);

        void Update(T entity);


        System.Threading.Tasks.Task UpdateAsync(T entity);



        T GetById(int Id);

        System.Threading.Tasks.Task<T> GetByIdAsync(int Id);


        void Delete(T entity);



        System.Threading.Tasks.Task DeleteAsync(T entity);


        bool DeleteById(int Id);


        System.Threading.Tasks.Task<bool> DeleteByIdAsync(int Id);


        System.Collections.Generic.IList<T> GetAll();


        System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();

    }
}
