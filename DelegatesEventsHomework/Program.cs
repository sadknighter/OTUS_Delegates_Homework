// See https://aka.ms/new-console-template for more information
using DelegatesEventsHomework;

Console.WriteLine("Hello, World!");
var list = new List<ExampleModel>
{
    new ExampleModel { ElementVal = 1.0f },
    new ExampleModel { ElementVal = .1f },
    new ExampleModel { ElementVal = 5.0f },
    new ExampleModel { ElementVal = 0.5f },
};

var maxValue = list.GetMax((t) => t.ElementVal);

Console.WriteLine("Found max element: {0}", maxValue);

//var path = @"C:\Users\SERVER\Desktop\TightVNCServerPortable\";
Console.Write("Please input path to start directory walker. >");
var path = Console.ReadLine();
var walker = new DirectoryWalker(path);
Console.WriteLine("Press Any Key to start walk");
Console.ReadKey();
Console.WriteLine("Press Any Key to stop walk");
walker.Walk();