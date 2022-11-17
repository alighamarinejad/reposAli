using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Base
{
   
        public abstract class UnitOfWork : Object, IUnitOfWork
        {
            public UnitOfWork(Tools.Options options) : base()
            {
                Options = options;

            }

            protected Tools.Options Options;


            private DataBaseContext _databasecontext;


            internal DataBaseContext DataBaseContext
            {
                get
                {
                    if (_databasecontext == null)
                    {
                        var OptionBuilder = new DbContextOptionsBuilder<DataBaseContext>();

                        switch (Options.Provider)
                        {
                            case Enums.Provider.SqlServer:
                                {
                                    OptionBuilder.UseSqlServer(connectionString: Options.ConnectionString);
                                    break;
                                }

                            case Enums.Provider.MySql:
                                break;
                            case Enums.Provider.InMemory:
                                break;
                            case Enums.Provider.Oracle:
                                break;
                            case Enums.Provider.PostGreSql:
                                break;
                            default:
                                break;
                        }


                        _databasecontext
                            = new DataBaseContext(OptionBuilder.Options);

                    }

                    return _databasecontext;
                }




            }





            Repository<T> IUnitOfWork.GetRepository<T>()
            {

                return new Repository<T>(databasecontext: DataBaseContext);

            }


            public void Save()
            {
                DataBaseContext.SaveChanges();
            }


            public async System.Threading.Tasks.Task SaveAsync()
            {

                await DataBaseContext.SaveChangesAsync();

            }



        }

}
