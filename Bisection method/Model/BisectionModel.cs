namespace Bisection_method.Model
{
    public class BisectionModel
    {
         public decimal PointA { get; set; }
         public decimal PointB { get; set; }
         public string Func { get; set; }
         public double Tol { get; set; }
         public int IterationMax { get; set; }
    }
}