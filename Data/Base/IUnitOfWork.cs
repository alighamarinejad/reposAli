using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Base
{
    public interface IUnitOfWork
    {
       

      public  void Save();

      public  System.Threading.Tasks.Task SaveAsync();


      public  Repository<T> GetRepository<T>() where T : Models.Base.entity;





    }
}
