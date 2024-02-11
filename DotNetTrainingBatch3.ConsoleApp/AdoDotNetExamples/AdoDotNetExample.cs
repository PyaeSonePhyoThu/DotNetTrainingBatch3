using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "MSI";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection Connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            Connection.Open();
            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[Tbl_Blog]";

            SqlCommand cmd = new SqlCommand(query, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Title..." + dr["BlogTitle"]);
                Console.WriteLine("Author..." + dr["BlogAuthor"]);
                Console.WriteLine("Content..." + dr["BlogContent"]);
            }

        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "MSI";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection Connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            Connection.Open();
            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[Tbl_Blog] Where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Connection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine("Title..." + dr["BlogTitle"]);
            Console.WriteLine("Author..." + dr["BlogAuthor"]);
            Console.WriteLine("Content..." + dr["BlogContent"]);
         

        }
        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "MSI";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection Connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            Connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                       ([BlogTitle]
                                       ,[BlogAuthor]
                                       ,[BlogContent])
                                 VALUES
                                       (@BlogTitle,
                                       ,@BlogAuthor
                                       ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();


            Connection.Close();

            string message = result > 0 ? "Saving Successfully" : "Saving Failed";

            Console.WriteLine(message); 
        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "MSI";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection Connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            Connection.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] =@BlogContent
                         WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            Connection.Close();

            string message = result > 0 ? "Update Successfully" : "Update Failed";

            Console.WriteLine(message);
        }
        public void Delete(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "MSI";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection Connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            Connection.Open();
            string query = @"Delete From [dbo].[Tbl_Blog]
                         WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();

            Connection.Close();

            string message = result > 0 ? "Update Successfully" : "Update Failed";

            Console.WriteLine(message);
        }
    }
}
