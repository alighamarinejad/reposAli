using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UserRepository:Base.Repository<Models.User>,Data.IUserRepository
    {
        internal UserRepository(Data.DataBaseContext dataBaseContext):base(dataBaseContext)
        {

        }


        //public Models.User GetUserEdit(string NationalID)
        //{
        //    Models.User UEntity = DbSet.Find(;
        //    return UEntity;

        //}


    }
}
