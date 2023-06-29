using Factory;
using Factory2;

var pageFactory = new ExecutePageVisionFactory();
pageFactory.Main();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
var appFactory = new ExecuteAppFactory();
appFactory.Main();