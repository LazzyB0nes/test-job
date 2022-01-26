namespace GeometryCalculator;

public static class Calculator
{
    private const int ONE_SIDE = 1;
    private const int THREE_SIDES = 3;
    static private Dictionary<int, Type> figures = new() {
        { ONE_SIDE, typeof(Circle)},
        { THREE_SIDES, typeof(Triangle)},
    };
    private static Circle? circle;
    private static Triangle? triangle;

    /// <summary>
    /// Расчёт площади фигуры по кол-ву переданных параметров
    /// Example: Square(2) - Расчёт площади круга по радиусу, Square(3, 4, 5) - Расчёт площади треугольника по трём сторонам
    /// </summary>
    static public double Square(params double[] segments)
    {
        Type figureType = figures[segments.Length];
        var parameters = segments.Select(seg => (object)seg).ToArray(); 
        object? figure = Activator.CreateInstance(figureType, parameters);
        
        if (figure is not null)
        {
            return ((ISquarable)figure).Square();
        }

        throw new NotImplementedException("Не определён тип фигуры");
    }
    
    /// <summary>
    /// Статический метод расчёта площади круга
    /// </summary>
    public static double CircleSquare(double radius) 
    {
        circle = new(radius);
        return circle.Square();
    }

    /// <summary>
    /// Статический метод расчёта площади треугольника
    /// </summary>
    public static double TriangleSquare(double hypotenuse, double opposite, double adjacent) 
    {
        triangle = new(hypotenuse, opposite, adjacent);
        return triangle.Square();
    }
}