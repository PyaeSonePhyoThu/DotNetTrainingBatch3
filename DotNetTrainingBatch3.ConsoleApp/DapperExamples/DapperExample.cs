using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DotNetTrainingBatch3.ConsoleApp.Models;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch3.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "MSI",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123"
            };
        public void Read()
        {
            
 
            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[Tbl_Blog]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();


            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine("Title..." + dr["BlogTitle"]);
            //    Console.WriteLine("Author..." + dr["BlogAuthor"]);
            //    Console.WriteLine("Content..." + dr["BlogContent"]);
            //}

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }

        }

        public void Edit(int id)
        {
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Tbl_Blog] Where BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new { BlogId = id }).FirstOrDefault();
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();
            //if(item == null)
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                       ([BlogTitle]
                                       ,[BlogAuthor]
                                       ,[BlogContent])
                                 VALUES
                                       (@BlogTitle,
                                       ,@BlogAuthor
                                       ,@BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content 
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,blog);
            string message = result > 0 ? "Saving Successfully" : "Saving Failed";

            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] =@BlogContent
                         WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Update Successfully" : "Update Failed";

            Console.WriteLine(message);
        }
        public void Delete(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"Delete From [dbo].[Tbl_Blog]
                         WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Update Successfully" : "Update Failed";

            Console.WriteLine(message);
        }
    }
}

