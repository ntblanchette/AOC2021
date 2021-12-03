using Common.IO;
using Common.Services;
using Day4;

var fileReader = new FileReader();
var mapper = new LineContentDay4Mapper();
var contentBreaker = new ContentBreaker<LineContentDay4>(mapper);
var calculator = new Day4Calculator();

var content = fileReader.GetFileContentAsList("Day4.txt");
var listOfContent = contentBreaker.BreakIntoObject(content);

var result1 = calculator.Calculate1(listOfContent);

Console.WriteLine($"The winning board result is: {result1}");

var result2 = calculator.Calculate2(listOfContent);

Console.WriteLine($"The last winning board result is: {result2}");