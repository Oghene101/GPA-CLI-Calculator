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

}
