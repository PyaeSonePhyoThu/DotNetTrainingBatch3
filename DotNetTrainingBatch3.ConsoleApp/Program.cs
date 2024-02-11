// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


DapperExample dapperExample = new DapperExample();
dapperExample.Read();
dapperExample.Create("Test", "Lee", "Loe");
dapperExample.Read();
