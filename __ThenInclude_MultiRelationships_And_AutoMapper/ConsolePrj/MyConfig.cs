using Infra.Config.DataAccess;

namespace ConsolePrj
{
    public static class MyConfig
    {
        public static DataAccessConfig DataAccessConfig { get; } = new DataAccessConfig
        {
            DataStoreMode = DataStoreMode.EF,
            //DataStoreMode = DataStoreMode.JSON,
            //DataStoreMode = DataStoreMode.SqlServer,
            //DataStoreMode = DataStoreMode.MySqlServer,
        };

    }
}
