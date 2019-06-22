using System;
using SquareToolsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquareToolsTests
{
	[TestClass]
	public class Circle_Square
	{
		//Задаем точность
		static readonly double Epsilon = 0.00001;

		[TestMethod]
		public void Circle_Square_TestNegative()
		{
			double radius = -1.0;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(radius));
		}

		[TestMethod]
		public void Circle_Square_TestZeroRadius()
		{
			double radius = 0.0;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(radius));
		}

		[TestMethod]
		public void Circle_Square_TestValue_2()
		{
			double radius = 2.0;

			double expected = 12.566368;

			Circle c = new Circle(radius);
			double actual = c.Square();
			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);

		}

		[TestMethod]
		public void Circle_Square_TestValue_42_7()
		{
			double radius = 42.7;

			double expected = 5728.03327768;

			Circle c = new Circle(radius);
			double actual = c.Square();
			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);
		}

		[TestMethod]
		public void Circle_Square_TestValue_0_5()
		{
			double radius = 0.5;

			double expected = 0.785398;

			Circle c = new Circle(radius);
			double actual = c.Square();
			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);

		}

		[TestMethod]
		public void Circle_Square_TestValue_12_05()
		{
			double radius = 12.05;

			double expected = 456.16701238;

			Circle c = new Circle(radius);
			double actual = c.Square();
			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);

		}

		[TestMethod]
		public void Circle_Square_TestValue_0_017()
		{
			double radius = 0.017;

			double expected = 0.000907920088;

			Circle c = new Circle(radius);
			double actual = c.Square();
			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);

		}
	}

	[TestClass]
	public class Triangle_Square
	{
		//Задаем точность
		static readonly double Epsilon = 0.00001;

		[TestMethod]
		public void Triangle_Square_TestInequality()
		{
			Assert.ThrowsException<Exception>(() => new Triangle(2, 3, 10));
		}

		[TestMethod]
		public void Triangle_Square_TestNegativeValue()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(-2, 3, 4));
		}

		[TestMethod]
		public void Triangle_Square_TestSingularValue()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(0.000001, 0.000002, 0.000003));
		}

		[TestMethod]
		public void Triangle_Square_TestSetValue1()
		{
			double fEdge = 5.3;
			double sEdge = 3.5;
			double tEdge = 4.01;
			double expected = 7.017243;

			Triangle triangle = new Triangle(fEdge, sEdge, tEdge);
			double actual = triangle.Square();

			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);
		}

		[TestMethod]
		public void Triangle_Square_TestSetValue2()
		{
			double fEdge = 10;
			double sEdge = 7;
			double tEdge = 4;
			double expected = 10.928746;

			Triangle triangle = new Triangle(fEdge, sEdge, tEdge);
			double actual = triangle.Square();

			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);
		}

		[TestMethod]
		public void Triangle_Square_TestSetValue3()
		{
			double fEdge = 0.0001;
			double sEdge = 0.0002;
			double tEdge = 0.0003;
			double expected = 0;

			Triangle triangle = new Triangle(fEdge, sEdge, tEdge);
			double actual = triangle.Square();

			Assert.IsTrue(Math.Abs(actual - expected) <= Epsilon);
		}

		[TestMethod]
		public void Triangle_Square_TestRight()
		{
			Triangle triangle1 = new Triangle(3, 4, 5);
			Triangle triangle2 = new Triangle(5, 12, 13);
			Triangle triangle3 = new Triangle(3, 5, 5);
			Triangle triangle4 = new Triangle(24, 143, 145);

			Assert.IsTrue(triangle1.IsRight());
			Assert.IsTrue(triangle2.IsRight());
			Assert.IsFalse(triangle3.IsRight());
			Assert.IsTrue(triangle4.IsRight());
		}
	}
}
