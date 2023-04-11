using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace kp4
{
    public  class SLAR
    {
        public  Vector<double> answers { get; set; }
        public   double count { get; set; }
        public   Vector<double> ThirdIterations { get; set; }
        public Matrix<double> matrix { get; set; }
        public Vector<double> vector { get; set; }
        public Vector<double> vectorR { get; set; } 
        public SLAR(Matrix<double> matrix, Vector<double> vector)
        {
            this.matrix = matrix;
            this.vector = vector;
        }
        public SLAR() {}
       public SLAR JacobiMethod()
        {           
            double X0 = 0;
            double X_1 = X0, X_2 = X0, X_3 = X0, X_4 = X0;
            double XLast_1, XLast_2, XLast_3, XLast_4;
            double dx = double.MaxValue;
            double epsilon = 0.001;
            double count = 0;
            while (Math.Abs(dx) > epsilon)
            {
                XLast_1 = X_1;
                XLast_2 = X_2;
                XLast_3 = X_3;
                XLast_4 = X_4;
                X_1 = (1 / matrix[0, 0]) * (vector[0] - matrix[0, 1] * XLast_2 - matrix[0, 2] * XLast_3 - matrix[0, 3] * XLast_4);
                X_2 = (1 / matrix[1, 1]) * (vector[1] - matrix[1, 0] * XLast_1 - matrix[1, 2] * XLast_3 - matrix[1, 3] * XLast_4);
                X_3 = (1 / matrix[2, 2]) * (vector[2] - matrix[2, 0] * XLast_1 - matrix[2, 1] * XLast_2 - matrix[2, 3] * XLast_4);
                X_4 = (1 / matrix[3, 3]) * (vector[3] - matrix[3, 0] * XLast_1 - matrix[3, 1] * XLast_2 - matrix[3, 2] * XLast_3);
                double[] range = { X_1 - XLast_1, X_2 - XLast_2, X_3 - XLast_3, X_4 - XLast_4 };
                double max = range.Max();
                dx = max;
                count++;
                if (count == 3)
                {
                    ThirdIterations = Vector<double>.Build.Dense(new double[] { Math.Abs(X_1-XLast_1), Math.Abs(X_2 - XLast_2), Math.Abs(X_3 - XLast_3), Math.Abs(X_4 - XLast_4) });
                }
            }
            this.count = count;
            answers = Vector<double>.Build.Dense(new double[] { X_1, X_2, X_3, X_4 });
            vectorR = Vector<double>.Build.Dense(new double[] {
            (X_1*matrix[0,0]+X_2*matrix[0,1]+X_3*matrix[0,2]+X_4*matrix[0,3])-vector[0],
            (X_1*matrix[1,0]+X_2*matrix[1,1]+X_3*matrix[1,2]+X_4*matrix[1,3])-vector[1],
            (X_1*matrix[2,0]+X_2*matrix[2,1]+X_3*matrix[2,2]+X_4*matrix[2,3])-vector[2],
            (X_1*matrix[3,0]+X_2*matrix[3,1]+X_3*matrix[3,2]+X_4*matrix[3,3])-vector[3],
            });

            return this;
        }
        public SLAR  GausMethod()
        {         
            double X0 = 0;
            double X_1 = X0, X_2 = X0, X_3 = X0, X_4 = X0;
            double XLast_1, XLast_2, XLast_3, XLast_4;
            double dx = double.MaxValue;
            double epsilon = 0.001;
            double count = 0;
            while (Math.Abs(dx) > epsilon)
            {
                XLast_1 = X_1;
                XLast_2 = X_2;
                XLast_3 = X_3;
                XLast_4 = X_4;
                X_1 = (1 / matrix[0, 0]) * (vector[0] - matrix[0, 1] * XLast_2 - matrix[0, 2] * XLast_3 - matrix[0, 3] * XLast_4);
                X_2 = (1 / matrix[1, 1]) * (vector[1] - matrix[1, 0] * X_1 - matrix[1, 2] * XLast_3 - matrix[1, 3] * XLast_4);
                X_3 = (1 / matrix[2, 2]) * (vector[2] - matrix[2, 0] * X_1 - matrix[2, 1] * X_2 - matrix[2, 3] * XLast_4);
                X_4 = (1 / matrix[3, 3]) * (vector[3] - matrix[3, 0] * X_1 - matrix[3, 1] * X_2 - matrix[3, 2] * X_3);
                double[] range = { X_1 - XLast_1, X_2 - XLast_2, X_3 - XLast_3, X_4 - XLast_4 };
                double max = range.Max();
                dx = max;
                count++;
                if (count == 3)
                {
                    ThirdIterations = Vector<double>.Build.Dense(new double[] { Math.Abs(X_1 - XLast_1), Math.Abs(X_2 - XLast_2), Math.Abs(X_3 - XLast_3), Math.Abs(X_4 - XLast_4) });
                }
            }
            this.count = count;
          answers = Vector<double>.Build.Dense(new double[] { X_1, X_2, X_3, X_4 });
            vectorR = Vector<double>.Build.Dense(new double[] {
            (X_1*matrix[0,0]+X_2*matrix[0,1]+X_3*matrix[0,2]+X_4*matrix[0,3])-vector[0],
            (X_1*matrix[1,0]+X_2*matrix[1,1]+X_3*matrix[1,2]+X_4*matrix[1,3])-vector[1],
            (X_1*matrix[2,0]+X_2*matrix[2,1]+X_3*matrix[2,2]+X_4*matrix[2,3])-vector[2],
            (X_1*matrix[3,0]+X_2*matrix[3,1]+X_3*matrix[3,2]+X_4*matrix[3,3])-vector[3],
            });
            return this;
        }

    }

}

