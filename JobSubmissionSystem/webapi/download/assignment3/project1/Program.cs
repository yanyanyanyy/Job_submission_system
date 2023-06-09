using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public interface Shape
    {
        double getArea();
        bool isVoliate();
    }

    public class Rectangle : Shape
    {
        private double height;
        private double width;
        
        public Rectangle(double height, double width)
        {
            
            this.height = height;
            this.width = width;
        }
        public double getArea()
        {
            return height*width;
        }
        public bool isVoliate()
        {
            return height > 0 && width > 0;
        }

    }

    public class Square : Rectangle
    {
        public Square(double size) : base(size, size) {}
    }

    public class Triangle : Shape
    {
        private double a;
        private double b;
        private double c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double getArea()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public bool isVoliate()
        {
            return !(a < 0 || b < 0 || c < 0 || a + b <= c || a + c <= b || b + c <= a);
        }
    }
    public class Project
    {
        public static void Main()
        {
            Shape shape = new Rectangle(5,5);
            Console.WriteLine("5*5的矩形面积为："+shape.getArea());
            shape = new Rectangle(-1, 5);
            Console.WriteLine("-1*5的矩形是否合理：" + shape.isVoliate());
            shape = new Square(5);
            Console.WriteLine("5的正方形面积为：" + shape.getArea());
            shape = new Square(-5);
            Console.WriteLine("-5的正方形是否合理：" + shape.isVoliate());
            shape = new Triangle(5,5,5);
            Console.WriteLine("5*5*5的三角形面积为：" + shape.getArea());
            shape = new Triangle(1,1,2);
            Console.WriteLine("1*1*2的三角形是否合理：" + shape.isVoliate());
            Console.ReadKey();
        }
    }
}
