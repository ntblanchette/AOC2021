using Common.IO;
using Common.Services;
using Day6;

var fileReader = new FileReader();
var mapper = new LineContentDay6Mapper();
var contentBreaker = new ContentBreaker<LineContentDay6>(mapper);
var calculator = new Day6Calculator();

var content = fileReader.GetFileContentAsList("Day6.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var result1 = calculator.Calculate1(listOfContent, 80);

Console.WriteLine($"The #1 result is: {result1}");

var result2 = calculator.Calculate1(listOfContent, 256);

Console.WriteLine($"The #2 result is: {result2}");