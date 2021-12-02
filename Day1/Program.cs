using Common.IO;
using Day1;

var fileReader = new FileReader();
var contentSplitter = new ContentSplitter();
var calculator = new IntCalculator();

var content = fileReader.GetFileContent("input");
var listOfInt = contentSplitter.SplitIntoInt(content);
var numberOfIncreases = calculator.GetIncreases(listOfInt);

Console.WriteLine($"Numbers has increased {numberOfIncreases} time(s).");

var listOfThreeMeasurement = calculator.GetThreeMeasurementList(listOfInt);
var numberOfIncreasesThreeMeasurement = calculator.GetIncreases(listOfThreeMeasurement);

Console.WriteLine($"Numbers in three-measurement has increased {numberOfIncreasesThreeMeasurement} time(s).");