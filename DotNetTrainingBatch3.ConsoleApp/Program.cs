// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


EFCoreExample  eFCoreExample = new EFCoreExample();

eFCoreExample.Read();
eFCoreExample.Edit(2);
eFCoreExample.Edit(13);