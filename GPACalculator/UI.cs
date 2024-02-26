using GPA.Logic;
using GPA.Model;
using ExtensionMethods;

namespace GPACalculator.UI;
public static class UI
{
    public static void UserPrompt(GPAModel gpaModel)
    {
        Console.Write("Enter course title: ");
        var courseTitle = Console.ReadLine();
        courseTitle.IsAValidCourseTitle();

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

    public static void Header(string studentFullName)
    {
        Console.WriteLine("|-----------------------------------------------------------------------------------------|");
        Console.WriteLine($"\t\t\t\t{studentFullName}'s Academic Record");
        Console.WriteLine("|-----------------------------------------------------------------------------------------|");
        Console.WriteLine($"SN|Course Title{"",-10}|  Course Code{"",-4}|  Unit{"",-5}|  Score{"",-5}|  GP{"",-5}|  WGP");
        Console.WriteLine("|-----------------------------------------------------------------------------------------|");
    }

    public static void Body(GPAModel gpaModel)
    {
        int number = 1;
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

    }
}
