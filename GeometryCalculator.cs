namespace GeometryCalculator;

public class Calculator
{
    private const int ONE_SIDE = 1;
    private const int THREE_SIDES = 3;
    private Dictionary<int, Type> figures = new() {
        { ONE_SIDE, typeof(Circle)},
        { THREE_SIDES, typeof(Triangle)},
    };
    private static Circle? circle;
    private static Triangle? triangle;
    public double Square(params double[] segments)
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
    public static double CircleSquare(double radius) 
    {
        circle = new(radius);
        return circle.Square();
    }
    public static double TriangleSquare(double hypotenuse, double opposite, double adjacent) 
    {
        triangle = new(hypotenuse, opposite, adjacent);
        return triangle.Square();
    }
}