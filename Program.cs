
double Y(double _x, double _a, double _b, double _c)
{
    return _a * _x * _x + _b * _x + _c;
}


double a, b, c = 0;       // Коэффициенты квадратного уравнения
double fa, fb, fc;      // Функции
double x1, x2;          // Корни уравнения
double eps = 0.000001;  //Точность вычесления корня

double[] y = new double[400];
double[] x = new double[400];
double startX = -100;

// запрашиваем у пользователя коэффициенты a, b и c квадратного уравнения
Console.WriteLine("Введите коэффициенты квадратного уравнения ax^2 + bx + c = 0:");
Console.Write("Введите a: ");
a = Convert.ToDouble(Console.ReadLine());
Console.Write("Введите b: ");
b = Convert.ToDouble(Console.ReadLine());
Console.Write("Введите c: ");
c = Convert.ToDouble(Console.ReadLine());

for (int i = 0; i < 400; i++)
{
    y[i] = Y(startX, a, b, c);
    x[i] = startX;
    startX += 0.5;
}
// проверяем, есть ли корни
double D = b * b - 4 * a * c;
if (D > 0)
{
    Console.WriteLine("Есть два корня");
}
else if (D == 0)
{
    Console.WriteLine("Есть один корень");
}
else
{
    Console.WriteLine("Корней нет");
}
for (int i = 0; i < y.Length - 1; i++)
{
    if (MathF.Sign((float)y[i]) + MathF.Sign((float)y[i + 1]) == 0)
    {
        Console.WriteLine("Тут будет корень!!! Между х1:{0} и х2:{1}", x[i], x[i + 1]);
        Console.WriteLine( "Получен корень: {0}",Koren(x[i],x[i+1],eps,a,b,c));
    }
    if (MathF.Sign((float)y[i]) == 0)
    {
        Console.WriteLine("Попали прям в корень, в точке:{0}", i);
    }
}



// метод половинного деления для нахождения корней уравнения
double Koren(double _x1, double _x2, double _eps, double _a, double _b, double _c)
{
    double x = Double.MaxValue;
    while (Math.Abs(_x2 - _x1) > _eps)
    {
        x = (_x1 + _x2) / 2;
        double f = _a * Math.Pow(x, 2) + _b * x + _c;
        if (f * (_a * Math.Pow(_x1, 2) + _b * _x1 + _c) < 0)
        {
            _x2 = x;
        }
        else
        {
            _x1 = x;
        }
    }
    return x;
}

