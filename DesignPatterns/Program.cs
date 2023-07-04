using Factory;
using Factory2;
using Builder;

Console.WriteLine("Factory");
var pageFactory = new ExecutePageVisionFactory();
pageFactory.Main();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
var appFactory = new ExecuteAppFactory();
appFactory.Main();

Console.WriteLine("Builder");
var builder = new ExecuteBuilder();
builder.Main();