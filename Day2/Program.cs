using Common.IO;
using Common.Services;
using Day2;

var fileReader = new FileReader();
var mapper = new LineContentDay2Mapper();
var contentBreaker = new ContentBreaker<LineContentDay2>(mapper);
var calculator = new Day2Calculator();

var content = fileReader.GetFileContentAsList("Day2.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var finalPosition1 = calculator.Calculate1(listOfContent);
Console.WriteLine($"The final position #1 is {finalPosition1.Compute()}");

var finalPosition2 = calculator.Calculate2(listOfContent);
Console.WriteLine($"The final position #2 is {finalPosition2.Compute()}");