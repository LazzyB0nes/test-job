namespace GeometryCalculator;

public class Circle : ISquarable 
{
    private double Radius { set; get; }
    public Circle(double radius) 
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException("Радиус должен быть больше нуля");

        Radius = radius;
    }
    /// <summary>
    /// Метод расчёта площади круга
    /// </summary>
    public double Square() => Math.PI * Radius * Radius;
}