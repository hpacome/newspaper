using System.Data;
using Dapper;

namespace newspaper.shared.integrationTest;

public static class DbHelper
{
    public static string ConnectionString = "";

    public static void InitDB(IDbConnection dbConnection, IEnumerable<string> sqlScript)
    {
        try
        {
            dbConnection.Open();
            foreach(string sql in sqlScript)
            {
                dbConnection.Execute(sql);
            }
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
