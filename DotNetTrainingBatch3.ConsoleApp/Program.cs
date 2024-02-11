// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(2);
//adoDotNetExample.Edit(11);

//adoDotNetExample.Create("Test_title", "Test_Author", "Test_Content");
adoDotNetExample.Update(2, "H", "E", "L");
//Console.ReadKey();
