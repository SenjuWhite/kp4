using MathNet.Numerics.LinearAlgebra;
Matrix<double> A15 = Matrix<double>.Build.DenseOfArray(new double[,]{
    {5.452, 0.401, 0.758,0.123},
    {0.785, 2.654, 0.687,0.203},
    {0.402,0.244,4.456,0.552},
    {0.210,0.514,0.206,4.568}
});
Vector<double> B15 = Vector<double>.Build.Dense(new double[] {0.886,0.356,0.342,0.452 });
Matrix<double> A16 = Matrix<double>.Build.DenseOfArray(new double[,]{
    {2.923, 0.220,0.159,0.328},
    {0.363,4.123,0.268,0.327},
    {0.169,0.271,3.906,0.295},
    {0.241,0.319,0.257,3.862}
});
Vector<double> B16 = Vector<double>.Build.Dense(new double[] { 0.605,0.496,0.590,0.896 });
Matrix<double> A23 = Matrix<double>.Build.DenseOfArray(new double[,]{
    {3.476,0.259,0.376,0.398},
    {0.425,4.583,0.417,0.328},
    {0.252,0.439,3.972,0.238},
    {0.265,0.291,0.424,3.864}
});
Vector<double> B23 = Vector<double>.Build.Dense(new double[] {0.871,0.739,0.644,0.581 });
Matrix<double> A24 = Matrix<double>.Build.DenseOfArray(new double[,]{
    {3.241,0.197,0.643,0.236},
    {0.257,3.853,0.342,0.427},
    {0.324,0.317,2.793,0.238},
    {0.438,0.326,0.483,4.229}
});
Vector<double> B24 = Vector<double>.Build.Dense(new double[] { 0.454,0.371,0.465,0.822 });
Console.WriteLine(JacobiMethod(B15, A15).ToString());
Console.WriteLine(JacobiMethod(B16, A16).ToString());
Console.WriteLine(JacobiMethod(B23, A23).ToString());
Console.WriteLine(JacobiMethod(B24, A24).ToString());
Console.WriteLine(GausMethod(B15, A15).ToString());
Console.WriteLine(GausMethod(B16, A16).ToString());
Console.WriteLine(GausMethod(B23, A23).ToString());
Console.WriteLine(GausMethod(B24, A24).ToString());

Vector<double> JacobiMethod(Vector<double> vector, Matrix<double> matrix)
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
       double[] result =  { X_1-XLast_1, X_2-XLast_2, X_3-XLast_3, X_4-XLast_4};
        double max = result.Max();
        dx = max;
        count++;      
    }

    return Vector<double>.Build.Dense(new double[] { X_1, X_2, X_3, X_4, count });
}
Vector<double> GausMethod(Vector<double> vector, Matrix<double> matrix)
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
        double[] result = { X_1 - XLast_1, X_2 - XLast_2, X_3 - XLast_3, X_4 - XLast_4 };
        double max = result.Max();
        dx = max;
        count++;
    }

    return Vector<double>.Build.Dense(new double[] { X_1, X_2, X_3, X_4, count });
}