using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Gauss_seidel();
            Console.ReadKey();
        }
                                             //GAUSS_SEIDEL METHOD OF OPTIMIZATION//
        static double f(double x1, double x2)
        {
            return (10 * Math.Pow(x1 * x1 - x2, 2) + 100 * Math.Pow(x1 - 1, 2)); //исходная функция
        }
        static void Gauss_seidel() //выполнение метода координатного спуска
        {
            double x1 = -1; //координата исходной точки
            double x2 = -1; //координата исходной точки
            double e = 0.001;
            double iter = 0;
            int repeat = 0;
            bool uslovie = false;
            Console.WriteLine($"x1 = {x1.ToString("0.0####")}\tx2 = {x2.ToString("0.0####")}\tF(x1, x2) = {f(x1, x2).ToString("0.00000")}");
        A: while (true)
            {
                if (f(x1, x2) > f(x1 + e, x2)) //увеличить первую координату Xi, условие выполняется, пока уменьшается функция
                {
                    x1 += e; //новое значение координаты
                    uslovie = true;
                }
                if (f(x1, x2) > f(x1 - e, x2)) //уменьшить первую координату Xi, условие выполняется, пока уменьшается функция
                {
                    x1 -= e; //вернуться к предыдущему значению координаты
                    uslovie = true;
                }

                if (uslovie == false) //условие остановки
                    break;
                else
                {
                    uslovie = false;
                    Console.WriteLine($"x1 = {x1.ToString("0.0####")}\tx2 = {x2.ToString("0.0####")}\tf(x1, x2) = {f(x1, x2).ToString("0.00000")}");
                }
                iter++;
            }
            while (true)
            {
                if (f(x1, x2) > f(x1, x2 + e)) //увеличить вторую координату Xi, условие выполняется, пока уменьшается функция
                {
                    x2 += e; //новое значение координаты
                    uslovie = true;
                }
                if (f(x1, x2) > f(x1, x2 - e)) //уменьшить вторую координату Xi, условие выполняется, пока уменьшается функция
                {
                    x2 -= e; //вернуться к предыдущему значению координаты
                    uslovie = true;
                }
                if (uslovie == false) //условие остановки
                    break;
                else
                {
                    uslovie = false;
                    Console.WriteLine($"x1 = {x1.ToString("0.0####")}\tx2 = {x2.ToString("0.0####")}\tF(x1, x2) = {f(x1, x2).ToString("0.00000")}");
                }
                iter++;
            }
            repeat++;
            if (repeat < 4) goto A; //повторить программу
            Console.WriteLine("Количество итераций: " + iter);
        }
        //END OF GAUSS_SEIDEL METHOD OF OPTIMIZATION//

                                                     //GRADIENT METHOD OF OPTIMIZATION//
        static double func(double x1, double x2)
        {
            return (10 * Math.Pow(x1 * x1 - x2, 2) + 100 * Math.Pow(x1 - 1, 2)); //высчитывание функции
        }
        static double functionx(double x1, double x2)
        {
            return (40 * x1 * (x1 * x1 - x2) + 2 * (x1 - 1)); //высчитывание частной производной по x
        }
        static double functiony(double x1, double x2)
        {
            return (-20 * (x1 * x1 - x2)); // высчитывание частной производной по y
        }

        static void Gradient()
        {
            double x1 = -1, x2 = -1; //начальные координаты точки
            double e = 0.001;
            int iter = 0; double Y;
            double h = 0.05, t = 20;
            double G = func(x1, x2);
            double x11, x22;

        P:
            x11 = x1;
            x22 = x2;
            x1 = x11 - h * functionx(x11, x22);
            x2 = x22 - h * functiony(x11, x22);
            Y = func(x1, x2);
            if (Math.Abs(Y - G) >= e)
            {
                if (Y > G)
                {
                    h = h / t;
                }
                G = Y;
                iter++;
                goto P;
            }
            Console.WriteLine("x1 = " + Math.Round(x1, 3) + "\r\nx2 = " + Math.Round(x2, 3) + "\r\nЗначение функции: F = " + Math.Round(func(x1, x2), 3));
            Console.WriteLine("Количество итераций: " + iter);
            Console.ReadLine();
        }
                                                   //END OF GRADIENT METHOD OF OPTIMIZATION//
    }
}
