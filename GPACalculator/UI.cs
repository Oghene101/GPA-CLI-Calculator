using GPA.Logic;
using GPA.Model;
using ExtensionMethods;

namespace GPACalculator.UI;
public static class UI
{
    public static void UserPrompt(GPAModel gpaModel)
    {
        bool active = true;
        while (active)
        {
            Console.Write("Enter course title: ");
            var courseTitle = Console.ReadLine();

            if (!courseTitle.IsAValidCourseTitle())
            {
                continue;
            }
            gpaModel.CourseTitles.Add(courseTitle);
            active = false;
        }

        active = true;
        while (active)
        {
            Console.Write("Enter course code: ");
            var courseCode = Console.ReadLine();

            if (!courseCode.IsAValidCourseCode())
            {
                continue;
            }
            gpaModel.CourseCodes.Add(courseCode);
            active = false;
        }

        active = true;
        while (active)
        {
            Console.Write("Enter course unit: ");
            var courseUnitText = Console.ReadLine();

            (bool isValid, int courseUnit) = courseUnitText.IsAValidNumber();
            
            if (!isValid)
            {
                continue;
            }
            gpaModel.CourseUnits.Add(courseUnit);
            active = false;
        }

        active = true;
        while (active)
        {
            Console.Write("Enter score in course: ");
            var courseScoreText = Console.ReadLine();

            (bool isValid, int courseScore) = courseScoreText.IsAValidNumber();

            if (!isValid)
            {
                continue;
            }
            gpaModel.CourseScores.Add(courseScore);

            //Determining the grade point from the score and adding it to the list of grade points.
            gpaModel.CourseGradePoints.Add(gpaModel.GetGradePoint(courseScore));
            active = false;
        }

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

    public static void Footer(GPAModel gpaModel)
    {
        var cwgp = GPAFormula.WeightGradePoints.Sum();
        var totalUnits = gpaModel.CourseUnits.Sum();
        Console.WriteLine($"Total Unit: {totalUnits}");
        Console.WriteLine($"CWGP: {cwgp}");
        Console.WriteLine($"GPA: {GPAFormula.CalculateGPA(cwgp, totalUnits)}");
    }
}
