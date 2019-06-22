using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareToolsLib
{
	public abstract class Figure
	{
		abstract public double Square();
	}

    public class Circle: Figure
    {
		public double Radius { set; get; }

		//Конструкторы
		public Circle()
		{
		}

		public Circle(double radiusValue)
		{
			if(radiusValue == 0)
			{
				throw new ArgumentOutOfRangeException("Ошибка: сингулярный круг");
			}
			if (radiusValue < 0.0)
			{
				throw new ArgumentOutOfRangeException("Ошибка: отрицательное значение радиуса");
			}
			Radius = radiusValue;
		}

		//Методы

		override public double Square()
		{
			return 3.141592 * Math.Pow(Radius, 2);
		}
    }

	public class Triangle : Figure
	{
		//Стороны треугольника
		public double FirstEdge { set; get; }
		public double SecondEdge { set; get; }
		public double ThirdEdge { set; get; }

		//Задаем точность
		private const double Epsilon = 0.00001;

		//Конструкторы
		public Triangle()
		{
		}

		public Triangle(double fEdge, double sEdge, double tEdge)
		{
			//Проверяем на вырожденность
			if (fEdge < Epsilon || sEdge < Epsilon || tEdge < Epsilon)
			{
				throw new ArgumentOutOfRangeException("Ошибка: вырожденный треугольник");
			}

			//Проверяем на отрицательные значения длин сторон
			if (fEdge < 0.0 || sEdge < 0.0 || tEdge < 0.0)
			{
				throw new ArgumentOutOfRangeException("Ошибка: получено отрицательное значение длины");
			}

			//Проверяем на выполнение неравенства треугольника
			bool exp1 = fEdge < sEdge + tEdge;
			bool exp2 = sEdge < fEdge + tEdge;
			bool exp3 = tEdge < sEdge + fEdge;

			if (!exp1 || !exp2 || !exp3)
			{
				throw new Exception("Ошибка: треугольник не существует, невыполнение неравенства треугольника");
			}

			FirstEdge  = fEdge;
			SecondEdge = sEdge;
			ThirdEdge  = tEdge;
		}

		//Методы

		public override double Square()
		{
			//Используем формулу Герона
			double semiPer = (FirstEdge + SecondEdge + ThirdEdge) / 2.0;
			return Math.Sqrt(semiPer * (semiPer - FirstEdge) * (semiPer - SecondEdge) * (semiPer - ThirdEdge));
		}

		//Проверка на правильный треугольник
		public bool IsRight()
		{
			return Math.Pow(FirstEdge, 2)  == Math.Pow(SecondEdge, 2) + Math.Pow(ThirdEdge, 2) ||
				   Math.Pow(ThirdEdge, 2)  == Math.Pow(FirstEdge, 2)  + Math.Pow(SecondEdge, 2) ||
				   Math.Pow(SecondEdge, 2) == Math.Pow(FirstEdge, 2) + Math.Pow(ThirdEdge, 2);
		}
	}
}
