using Factory;
using Factory2;

var returnHumans = new ExecuteFirstFactory();
returnHumans.Main();
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
var returnHumans2 = new ExecuteSecondFactory();
returnHumans2.Main();