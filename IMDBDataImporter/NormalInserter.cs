using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBDataImporter
{
    public class NormalInserter
    {
        private string ConnString = "server=localhost,database=IMDB"+"user id=sa, " +
            "password=testkode,TrustServerCertificate=True";

        public void InsertData(List<Title> titles)
        {
            SqlConnection sqlConn= new SqlConnection(ConnString);
            sqlConn.Open();

            foreach(Title title in titles)
            {
                SqlCommand sqlCommand= new SqlCommand(
                    "" +
                    "INSERT INTO [dbo].[Titles]" +
                    "([tconst],[titleType],[primaryTitle],[originalTitle]" +
                    "[isAdult],[startYear],[endYear],[runTimeMinutes])" +
                    "VALUES" +
                    $"('{title.tconst}','{title.titleType}'," +
                    $"('{title.primaryTitle}','{title.originalTitle}'," +
                    $"({title.isAdult},{title.startYear}," +
                    $"({title.endYear},{title.runTimeMinutes})," 
                    , sqlConn);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    Console.WriteLine(sqlCommand.CommandText);
                }
                
            }
        }
    }
}
