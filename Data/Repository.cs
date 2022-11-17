using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Repository<T> : Base.Repository<T> where T : Models.Base.entity
    {
        internal Repository(DataBaseContext databasecontext) : base(databasecontext)
        {

        }
    }
}
