namespace GPA.Logic;
public static class GPAFormula
{
    public static List<decimal> weightGradePoints { get; } = [];
    public static decimal CalculateWGP(int courseUnit, decimal courseGradePoint)
    {
        var weightGradePoint = courseUnit * courseGradePoint;
        GPAFormula.weightGradePoints.Add(weightGradePoint);
        return weightGradePoint;
    }
    public static decimal CalculateGPA(decimal cwgp, int totalUnits)
    {
        return Math.Round(cwgp / totalUnits, 2);
    }
}
