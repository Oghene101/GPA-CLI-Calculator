using GPA.Logic;
using GPA.Model;
using GPACalculator.UI;

Console.WriteLine("Welcome to the GPA calculator created by Ogheneruemu Karieren");

Console.Write("Please enter student's fullname: ");
var studentFullName = Console.ReadLine();

Console.Write("How many courses did you offer? ");
var numberOfCoursesOfferedText = int.TryParse(Console.ReadLine(), out int numberOfCoursesOffered);

var gpaModel = new GPAModel();
for(int courses = 0; courses < numberOfCoursesOffered; courses++)
{
    UI.UserPrompt(gpaModel);
}

UI.Header(studentFullName);

UI.Body(gpaModel);

var cwgp = GPAFormula.WeightGradePoints.Sum();
var totalUnits = gpaModel.CourseUnits.Sum();
Console.WriteLine($"Total Unit: {totalUnits}");
Console.WriteLine($"CWGP: {cwgp}");
Console.WriteLine($"GPA: {GPAFormula.CalculateGPA(cwgp, totalUnits)}");