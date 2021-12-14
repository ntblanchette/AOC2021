using Common.IO;
using Common.Services;
using Day10;

var fileReader = new FileReader();
var mapper = new LineContentDay10Mapper();
var contentBreaker = new ContentBreaker<LineContentDay10>(mapper);
var calculator = new Day10Calculator();

var content = fileReader.GetFileContentAsList("Day10.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var result1 = calculator.Calculate1(listOfContent);

Console.WriteLine($"The #1 result is: {result1}");

var result2 = calculator.Calculate2(listOfContent);

Console.WriteLine($"The #2 result is: {result2}");