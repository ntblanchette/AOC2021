using Common.IO;
using Common.Services;
using Day1;

var fileReader = new FileReader();
var lineContentDay1Mapper = new LineContentDay1Mapper();
var contentBreaker = new ContentBreaker<LineContentDay1>(lineContentDay1Mapper);
var calculator = new Day1Calculator();

var content = fileReader.GetFileContentAsList("input");
var listOfContent = contentBreaker.BreakIntoObject(content);

var numberOfIncreases = calculator.GetIncreases(listOfContent);
Console.WriteLine($"Numbers has increased {numberOfIncreases} time(s).");

var numberOfIncreasesThreeMeasurement = calculator.GetThreeMeasurementListIncreases(listOfContent);
Console.WriteLine($"Numbers in three-measurement has increased {numberOfIncreasesThreeMeasurement} time(s).");