using System;
using System.Threading;
using Bisection_method.Model;
using parserDecimal.Parser;

namespace Bisection_method
{
    class Bisection
    {
         public event Action<int> ProgressBarIncrement; 
        readonly Computer _computer = new Computer();
        private decimal Function(decimal x1, string func)
        {
            return _computer.Compute(func, x1);
        }

        private int sign(decimal x)
        {
            if (x > 0) { return 1; }
            else if (x == 0) { return 0; }
            else if (x < 0) { Thread.Sleep(1); return -1; }
            else return 5;
        }

        public BisectionViewModel Calculate(BisectionModel model)
        {
            decimal m;
            decimal fm;
            var fa = Function(model.PointA, model.Func);
            var fb = Function(model.PointB, model.Func);

            if (sign(fa) == sign(fb))
                return new BisectionViewModel {Error = @"Знаки Fa и Fb  должны быть разными, проверьте диапазон [a, b]"};

            var iteration = 0;

            do
            {
                ProgressBarIncrement?.Invoke(1);
                m = model.PointA + (model.PointB - model.PointA) / 2;
                fa = Function(model.PointA, model.Func);
                fm = Function(m, model.Func);
                if (sign(fa) == sign(fm))
                    model.PointA = m;
                else
                    model.PointB = m;

                iteration++;
            } while (model.PointB - model.PointA > (decimal) model.Tol && iteration < model.IterationMax);

            if(iteration < model.IterationMax)
                ProgressBarIncrement?.Invoke(model.IterationMax - iteration);

            return new BisectionViewModel
            {
                X = m,
                Iteration = iteration,
                Abc = model.PointB - model.PointB,
                Fx = fm
            };
        }

    }
}
