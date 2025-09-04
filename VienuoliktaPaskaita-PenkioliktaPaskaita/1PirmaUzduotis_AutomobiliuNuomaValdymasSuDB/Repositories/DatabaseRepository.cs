using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models;
using System.Data;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Repositories
{
        public class DatabaseRepository : IDatabaseRepository
        {
                private readonly string _connectionString;
                public DatabaseRepository(string connectionString)
                {
                        _connectionString = connectionString;
                }

                public void AddElektrinisAutomobilis(ElektrinisAutomobilis naujasAutomobilis)
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"INSERT INTO Automobilis (Markė, Modelis, [Gamybos Metai], [Reg. Nr.]) VALUES (@Marke, @Modelis, @Gamybosmetai, @RegNr); SELECT CAST(SCOPE_IDENTITY() as int);";
                                const string sql1 = @"INSERT INTO AutomobilisElektrinis([EA ID], [Baterijos Talpa]) Values (@AutomobilioId, @BaterijosTalpa);";
                                naujasAutomobilis.AutomobilioId = db.ExecuteScalar<int>(sql, naujasAutomobilis);
                                db.Execute(sql1, naujasAutomobilis);
                        }
                }
                public void AddNaftosKuroAutomobilis(NaftosKuroAutomobilis naujasAutomobilis)
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"INSERT INTO Automobilis (Markė, Modelis, [Gamybos Metai], [Reg. Nr.]) VALUES (@Marke, @Modelis, @Gamybosmetai, @RegNr); SELECT CAST(SCOPE_IDENTITY() as int);";
                                const string sql1 = @"INSERT INTO AutomobilisNaftos([NA ID], [Bako Talpa]) Values (@AutomobilioId, @BakoTalpa)";
                                naujasAutomobilis.AutomobilioId = db.ExecuteScalar<int>(sql, naujasAutomobilis);
                                db.Execute(sql, naujasAutomobilis);
                                db.Execute(sql1, naujasAutomobilis);
                        }
                }

                public void UpdateElektrinisAutomobilis(ElektrinisAutomobilis naujasAutomobilis)
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                        const string sql = @"UPDATE Automobilis SET Markė = @Marke, Modelis = @Modelis, [Gamybos Metai] = @Gamybosmetai, [Reg. Nr.] = @RegNr WHERE ID = @AutomobilioId)";
                        const string sql1 = @"UPDATE AutomobilisElektrinis SET [Baterijos Talpa] = @BaterijosTalpa WHERE [EA ID] = @AutomobilioId;";
                               db.Execute(sql1, naujasAutomobilis);
                                db.Execute(sql, naujasAutomobilis);
                        }
                        
                }

                public void UpdateNaftosKuroAutomobilis(NaftosKuroAutomobilis naujasAutomobilis)
                {
                        using(IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"UPDATE Automobilis SET Markė = @Marke, Modelis = @Modelis, [Gamybos Metai] = @Gamybosmetai, [Reg. Nr.] = @RegNr WHERE ID = @AutomobilioId;)";
                                const string sql1 = @"UPDATE AutomobilisNaftos SET [Bako Talpa] = @BakoTalpa WHERE [NA ID] = @AutomobilioId;";
                                db.Execute(sql1, naujasAutomobilis);
                                db.Execute(sql, naujasAutomobilis);
                        }
                }
                
                public void DeleteElektrinisAutomobilis(int id)
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"DELETE FROM AutomobilisElektrinis  WHERE [EA ID] = @id;";
                                const string sql1 = @"DELETE FROM Automobilis WHERE ID = @id";
                                db.Execute(sql, new { id });  
                                db.Execute(sql1, new { id });
                        }
                }

                public void DeleteNaftosKuroAutomobilis(int id)
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"DELETE FROM AutomobilisNaftos WHERE [NA ID] = @id;";
                                const string sql1 = @"DELETE FROM Automobilis WHERE ID = @id";
                                db.Execute(sql, new { id });
                                db.Execute(sql1, new { id });
                        }
                }
                public IEnumerable<ElektrinisAutomobilis> GetElektrinisAutomobiliuSarasas()
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"
                        SELECT  ID as AutomobilioId, Markė as Marke, Modelis, [Gamybos Metai] as Gamybosmetai, [Reg. Nr.] as RegNr, [Baterijos Talpa] as BaterijosTalpa FROM Automobilis
                        RIGHT JOIN AutomobilisElektrinis
                        ON Automobilis.ID = AutomobilisElektrinis.[EA ID]
                        ORDER BY Automobilis.ID ASC";

                                return db.Query<ElektrinisAutomobilis>(sql);
                        }
                }

                public IEnumerable<NaftosKuroAutomobilis> GetNaftosAutomobiliuSarasas()
                {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                                const string sql = @"
                        SELECT  ID as AutomobilioId, Markė as Marke, Modelis, [Gamybos Metai] as Gamybosmetai, [Reg. Nr.] as RegNr, [Bako Talpa] as BakoTalpa FROM Automobilis
                        RIGHT JOIN AutomobilisNaftos
                        ON Automobilis.ID = AutomobilisNaftos.[NA ID]
                        ORDER BY Automobilis.ID ASC";

                                return db.Query<NaftosKuroAutomobilis>(sql);
                        }
                }

               
        }
}
