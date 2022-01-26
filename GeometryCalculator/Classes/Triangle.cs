namespace GeometryCalculator;

public class Triangle : ISquarable 
{
    private double SideA;
    private double SideB;
    private double SideC;
    
    /// <summary>
    /// Флаг, является ли треугольник прямоугольным
    /// </summary>
    public bool IsRightAngled => CheckIsRightAngled();

    public Triangle(double sideA, double sideB, double sideC)
    {   
        if (sideA < 0 || sideB < 0 || sideC < 0)
            throw new ArgumentOutOfRangeException("Все стороны должны быть больше нуля");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    /// <summary>
    /// Метод расчёта площади треугольника
    /// </summary>
    public double Square() 
    {
        double semiPerimeter = (SideA + SideB + SideC) / 2;

        double hypotenusePart = semiPerimeter - SideA;
        double oppositePart = semiPerimeter - SideB;
        double SideCPart = semiPerimeter - SideC;

        return Math.Sqrt(semiPerimeter * hypotenusePart * oppositePart * SideCPart);
    }
    private bool CheckIsRightAngled()
    {
        double[] trianlgeSides = new double[] {SideA, SideB, SideC};

        double hypotenuse = trianlgeSides.Max();
        trianlgeSides = trianlgeSides.Where(side => side < hypotenuse).ToArray();

        double sideB = trianlgeSides.First();
        double sideC = trianlgeSides.Last();
        return hypotenuse * hypotenuse == sideB * sideB + sideC * sideC;
    }
}
