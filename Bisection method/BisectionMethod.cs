using parserDecimal.Parser;
using System.Threading;

namespace BisectionMmethod
{
    class Bisection
    {
        decimal Fa, Fb, a, b, x, m, Fm;
        double tol;
        int k = 0;
        string func;
        Computer computer = new Computer();
        public Bisection()
        {
        }
        public decimal Function(decimal x1)
        {
            return computer.Compute(func, x1);
        }

        private int sign(decimal x)
        {
            
            if (x > (decimal)0) { return 1; }
            else if (x == (decimal)0) { return 0; }
            else if (x < (decimal)0) { Thread.Sleep(1); return -1; }
            else return 5;
        }

        public dynamic Calculate(decimal a, decimal b, string _func, double tol, int k_max)
        {
            func = _func;
            Fa = Function(a);
            Fb = Function(b);
            if (sign(Fa) == sign(Fb)) { return new { err = "Знаки Fa и Fb  должны быть разными, проверьте диапазон [a, b]" }; }
            k = 0;

            do
            {
                m = a + (b - a) / 2;
                Fa = Function(a);
                Fm = Function(m);
                if (sign(Fa) == sign(Fm)) { a = m; }
                else { b = m; }
                k++;

            }
            while (((decimal)b - a) > (decimal)tol && k < k_max);
            Thread.Sleep(50);
            return new { X = m, fx = Fm, iteration = k, Abc = b - a, err = "" };
        }

    }
}
