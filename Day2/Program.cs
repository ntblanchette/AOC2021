using Common.IO;
using Common.Services;
using Day2;

var fileReader = new FileReader();
var lineContentDay2Mapper = new LineContentDay2Mapper();
var contentBreaker = new ContentBreaker<LineContentDay2>(lineContentDay2Mapper);
var day2Calculator = new Day2Calculator();

var content = fileReader.GetFileContentAsList("Day2.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var finalPosition1 = day2Calculator.Calculate1(listOfContent);
Console.WriteLine($"The final position #1 is {finalPosition1.Compute()}");

var finalPosition2 = day2Calculator.Calculate2(listOfContent);
Console.WriteLine($"The final position #2 is {finalPosition2.Compute()}");