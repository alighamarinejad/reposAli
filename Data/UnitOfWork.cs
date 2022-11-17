using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Tools.Options options) : base(options)
        {

        }

        private IUserRepository _UserRepository;
        private IPhoneBookRepository _PhoneBookRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_UserRepository == null)
                {
                    _UserRepository = new UserRepository(DataBaseContext);
                }
                return _UserRepository;

            }

        }

        public IPhoneBookRepository PhoneBookRepository
        {
            get
            {
                if (_PhoneBookRepository == null)
                {
                    _PhoneBookRepository =
                        new PhoneBookRepository(DataBaseContext);
                }

                return _PhoneBookRepository;
            }
        }




    }
}
