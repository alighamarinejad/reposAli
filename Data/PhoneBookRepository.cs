using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class PhoneBookRepository:Base.Repository<Models.PhoneBook>,IPhoneBookRepository
    {
        internal PhoneBookRepository(Data.DataBaseContext dataBaseContext):base(dataBaseContext)
        {

        }


       
    }
}
