using Common.IO;
using Common.Services;
using Day3;

var fileReader = new FileReader();
var mapper = new LineContentDay3Mapper();
var contentBreaker = new ContentBreaker<LineContentDay3>(mapper);
var calculator = new Day3Calculator();

var content = fileReader.GetFileContentAsList("Day3.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var result1 = calculator.Calculate1(listOfContent);

Console.WriteLine($"The power consumption of the submarine is: {result1}");

var result2 = calculator.Calculate2(listOfContent);

Console.WriteLine($"The life support rating of the submarine is: {result2}");