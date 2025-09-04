using Dapper;
using AutomobiliuNuomaWebPage.Models;
using System.Data;    
using System.Data.SqlClient;

namespace AutomobiliuNuomaWebPage.Services

{
        public class DataBaseService : IDatabaseService
        {
                private readonly string _connectionString;
                public DataBaseService(string connectionString)
                {
                        _connectionString = connectionString;
                }
                public IEnumerable<Automobilis> GetAutomobilis()
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"

                                       ";


                                return db.Query<Automobilis>(sql);
                        }
                }
        }
}
