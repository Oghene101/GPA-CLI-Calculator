using GPA.Logic;
using GPA.Model;

Console.WriteLine("Welcome to the GPA calculator created by Ogheneruemu Karieren");

Console.Write("Please enter student's fullname: ");
var studentFullName = Console.ReadLine();

Console.Write("How many courses did you offer? ");
var numberOfCoursesOfferedText = int.TryParse(Console.ReadLine(), out int numberOfCoursesOffered);

var gpaModel = new GPAModel();
for(int courses = 0; courses < numberOfCoursesOffered; courses++)
{
    Console.Write("Enter course title: ");
    var courseTitle = Console.ReadLine();
    gpaModel.CourseTitles.Add(courseTitle);

    Console.Write("Enter course code: ");
    var courseCode = Console.ReadLine();
    gpaModel.CourseCodes.Add(courseCode);

    Console.Write("Enter course unit: ");
    var courseUnitText = int.TryParse(Console.ReadLine(), out int courseUnit);
    gpaModel.CourseUnits.Add(courseUnit);

    Console.Write("Enter score in course: ");
    var courseScoreText = int.TryParse(Console.ReadLine(), out int courseScore);
    gpaModel.CourseScores.Add(courseScore);

    //Determining the grade point from the score and adding it to the list of grade points.
    gpaModel.CourseGradePoints.Add(gpaModel.GetGradePoint(courseScore));

    Console.Clear();
}

int number = 1;
Console.WriteLine("|-----------------------------------------------------------------------------------------|");
Console.Write($"\t\t\t\t\t\t{studentFullName}'s Academic Record");
Console.WriteLine($"SN|Course Title{"",-10}|  Course Code{"",-4}|  Unit{"",-5}|  Score{"",-5}|  GP{"", -5}|  WGP");
Console.WriteLine("|-----------------------------------------------------------------------------------------|");
for (int i = 0; i < gpaModel.CourseUnits.Count && i < gpaModel.CourseGradePoints.Count; i++)
{
    var unit = gpaModel.CourseUnits[i];
    var courseGradePoint = gpaModel.CourseGradePoints[i];

    var weightGradePoint = GPAFormula.CalculateWGP(unit, courseGradePoint);

    var courseTitle = gpaModel.CourseTitles[i];
    var courseCode = gpaModel.CourseCodes[i];
    var courseScore = gpaModel.CourseScores[i];

    Console.WriteLine("|-----------------------------------------------------------------------------------------|");
    Console.WriteLine($"{number++}.|{courseTitle,-22}|  {courseCode,-15}|  {unit,-9}|  {courseScore,-10}|" +
        $"  {courseGradePoint,-7}|  {weightGradePoint}");
    Console.WriteLine("|-----------------------------------------------------------------------------------------|\n\n");
}

var cwgp = GPAFormula.weightGradePoints.Sum();
var totalUnits = gpaModel.CourseUnits.Sum();
Console.WriteLine($"Total Unit: {totalUnits}");
Console.WriteLine($"CWGP: {cwgp}");
Console.WriteLine($"GPA: {GPAFormula.CalculateGPA(cwgp, totalUnits)}");
