using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Configuration;


namespace mantis_tests
{
    public class MantisDB : LinqToDB.Data.DataConnection
    {
        public MantisDB() : base("MantisDb")
        {
        }

        public ITable<ProjectData> Projects => GetTable<ProjectData>();
    }

    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }

        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
        {
            get { yield break; }
        }

        public string DefaultConfiguration => "MantisDb";
        public string DefaultDataProvider => ProviderName.MySql;

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "MantisDb",
                        ProviderName = "MySql.Data.MySqlClient",
                        ConnectionString =
                            @"Server=localhost;Port=3306;Database=bugtracker;Uid=pma;Pwd=norm;Allow Zero Datetime = True;Connection Timeout=35"
                    };
            }
        }
    }
}