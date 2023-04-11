using kp4;
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
SLAR slar15 = new SLAR(A15,B15);
SLAR slar16 = new SLAR(A16, B16);
SLAR slar23 = new SLAR(A23,B23);
SLAR slar24 = new SLAR(A24,B24);
slar15.JacobiMethod();
slar16.JacobiMethod();
slar23.JacobiMethod();
slar24.JacobiMethod();
Console.WriteLine($"{slar15.answers.ToString()}\n Кількість ітерацій:{slar15.count}\n Похибки на 3 ітераціїї: \n{slar15.ThirdIterations}\n Вектор нев'язки:\n{slar15.vectorR}");
Console.WriteLine($"{slar16.answers.ToString()}\n Кількість ітерацій:{slar16.count}\n Похибки на 3 ітераціїї: \n{slar16.ThirdIterations}\n Вектор нев'язки:\n{slar16.vectorR}");
Console.WriteLine($"{slar23.answers.ToString()}\n Кількість ітерацій:{slar23.count}\n Похибки на 3 ітераціїї: \n{slar23.ThirdIterations}\n Вектор нев'язки:\n{slar23.vectorR}");
Console.WriteLine($"{slar24.answers.ToString()}\n Кількість ітерацій:{slar24.count}\n Похибки на 3 ітераціїї: \n{slar24.ThirdIterations}\n Вектор нев'язки:\n{slar24.vectorR}");
slar15.GausMethod();
slar16.GausMethod();
slar23.GausMethod();
slar24.GausMethod();
Console.WriteLine($"{slar15.answers.ToString()}\n Кількість ітерацій:{slar15.count}\n Похибки на 3 ітераціїї: \n{slar15.ThirdIterations}\n Вектор нев'язки:\n{slar15.vectorR}");
Console.WriteLine($"{slar16.answers.ToString()}\n Кількість ітерацій:{slar16.count}\n Похибки на 3 ітераціїї: \n{slar16.ThirdIterations}\n Вектор нев'язки:\n{slar16.vectorR}");
Console.WriteLine($"{slar23.answers.ToString()}\n Кількість ітерацій:{slar23.count}\n Похибки на 3 ітераціїї: \n{slar23.ThirdIterations}\n Вектор нев'язки:\n{slar23.vectorR}");
Console.WriteLine($"{slar24.answers.ToString()}\n Кількість ітерацій:{slar24.count}\n Похибки на 3 ітераціїї: \n{slar24.ThirdIterations}\n Вектор нев'язки:\n{slar24.vectorR}");




 