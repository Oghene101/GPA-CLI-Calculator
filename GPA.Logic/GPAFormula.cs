namespace GPA.Logic;
public static class GPAFormula
{
    public static List<decimal> WeightGradePoints { get; } = [];
    public static decimal CalculateWGP(int courseUnit, decimal courseGradePoint)
    {
        var weightGradePoint = courseUnit * courseGradePoint;
        GPAFormula.WeightGradePoints.Add(weightGradePoint);
        return weightGradePoint;
    }
    public static decimal CalculateGPA(decimal cwgp, int totalUnits)
    {
        return Math.Round(cwgp / totalUnits, 2);
    }
}
