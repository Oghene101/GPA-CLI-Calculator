using System.Text.RegularExpressions;

namespace ExtensionMethods;
public static class ExtensionMethods
{
    public static bool IsAValidCourseTitle(this string courseTitle)
    {
        var pattern = @"^[A-Za-z- ]+$";
        Regex regex = new Regex(pattern);
        var isAWord = regex.IsMatch(courseTitle);
        if (!isAWord || courseTitle.Trim('-').Length is 0)
        {
            Console.WriteLine("Enter a valid course title!");
            return false;
        }
        return true;
    }

    public static bool IsAValidCourseCode(this string courseCode)
    {
        var pattern = @"^(?=.*[A-Z])(?=.*[0-9])[A-Z0-9 ]+$";//Positive look ahead assertion
        Regex regex = new(pattern);
        var isAWord = regex.IsMatch(courseCode);
        if (!isAWord)
        {
            Console.WriteLine("Enter a valid course code!");
            return false;
        }
        return true;
    }

    public static (bool, int) IsAValidNumber(this string text)
    {
        if(!int.TryParse(text, out var parsedNumber))
        {
            Console.WriteLine("Enter a valid course unit!");
            return (false, -1);
        }
        return (true, parsedNumber);
    }
}