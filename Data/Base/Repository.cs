using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Base
{
    public class Repository<T> : Object, IRepository<T> where T : Models.Base.entity
    {
        internal Repository(Data.DataBaseContext databasecontext)
        {


            DataBaseContext = databasecontext ?? throw new System.ArgumentNullException(paramName: "databasecontext");

            DbSet = DataBaseContext.Set<T>();

        }

        internal Data.DataBaseContext DataBaseContext { get; }


        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }


        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Add(entity);

        }


        public virtual async System.Threading.Tasks.Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));

            }

            await DbSet.AddAsync(entity);

        }

        public virtual async System.Threading.Tasks.Task InsertAsyn(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);

        }


        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);

        }

        public virtual async System.Threading.Tasks.Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await System.Threading.Tasks.Task.Run(() =>
            {


                DbSet.Update(entity);

            });

        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Remove(entity);
        }

        public virtual async System.Threading.Tasks.Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }


            await System.Threading.Tasks.Task.Run(() =>
            {

                DbSet.Remove(entity);

            });

        }

        public virtual bool DeleteById(int Id)
        {
            T entity = DbSet.Find(Id);
            if (entity == null)
            {
                return false;
            }

            DbSet.Remove(entity);


            return true;
        }


        public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(int Id)
        {
            T entity = await DbSet.FindAsync(Id);

            if (entity == null)
            {
                return false;
            }

            await System.Threading.Tasks.Task.Run(() =>
            {

                DbSet.Remove(entity);
            });

            return true;
        }


        public virtual T GetById(int Id)
        {

            T entity = DbSet.Find(Id);

            return entity;

        }

        public virtual async System.Threading.Tasks.Task<T> GetByIdAsync(int Id)
        {
            T entity = await DbSet.FindAsync(Id);

            return entity;
        }


        public virtual System.Collections.Generic.IList<T> GetAll()
        {

            var result =

                DbSet.ToList()
                ;

            return result;
        }

        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
        {

            var result =

              await DbSet.ToListAsync()
                ;

            return result;
        }




    }
}
