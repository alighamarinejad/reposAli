using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        public IPhoneBookRepository PhoneBookRepository { get; }

        public IUserRepository UserRepository { get; }

    }
}
