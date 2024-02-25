namespace GPA.Model;
public class GPAModel
{
    public List<string> CourseTitles { get; } = [];
    public List<string> CourseCodes { get; } = [];
    public List<int> CourseUnits { get; } = [];
    public List<int> CourseScores { get; } = [];
    public List<decimal> CourseGradePoints { get; } = [];

    public char GetGrade(int courseScore)
    {
        if (courseScore >= 70)
        {
            return 'A';
        }
        else if (courseScore >= 60)
        {
            return 'B';
        }
        else if (courseScore >= 50)
        {
            return 'C';
        }
        else if (courseScore >= 45)
        {
            return 'D';
        }
        else if (courseScore >= 40)
        {
            return 'E';
        }
        else
        {
            return 'F';
        }
    }

    public decimal GetGradePoint(int courseScore)
    {
        if (courseScore >= 70)
        {
            return 5.0M;
        }
        else if (courseScore >= 60)
        {
            return 4.0M;
        }
        else if (courseScore >= 50)
        {
            return 3.0M;
        }
        else if (courseScore >= 45)
        {
            return 2.0M;
        }
        else if (courseScore >= 40)
        {
            return 1.0M;
        }
        else
        {
            return 0;
        }
    }
}
