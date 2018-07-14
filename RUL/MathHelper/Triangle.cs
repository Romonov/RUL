using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUL.MathHelper
{
    class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            if (a + b < c 
                || b + c < a 
                || a + c < b
                || a - b > c
                || b - c > a
                || a - c > b
                || b - a > c
                || c - b > a
                || c - a > b)
            {
                return true;
            }
            return false;
        }

        public static double GetArea(double a, double b, double c)
        {
            if (!IsTriangle(a, b, c))
            {
                return -1;
            }

            double p = (a + b + c) / 2;

            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return area;
        }
    }
}
