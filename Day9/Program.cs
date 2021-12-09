using Common.IO;
using Common.Services;
using Day9;

var fileReader = new FileReader();
var mapper = new LineContentDay9Mapper();
var contentBreaker = new ContentBreaker<LineContentDay9>(mapper);
var calculator = new Day9Calculator();

var content = fileReader.GetFileContentAsList("Day9.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var result1 = calculator.Calculate1(listOfContent);

Console.WriteLine($"The #1 result is: {result1}");

var result2 = calculator.Calculate2(listOfContent);

Console.WriteLine($"The #2 result is: {result2}");