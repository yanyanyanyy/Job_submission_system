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
    public class ShapeFactory
    {   
        private static int maxSize = 100;
        private static Random random = new Random();
        public static Shape getShape(string name) { 
            if (name.Equals("三角形"))
            {
                double height = random.NextDouble()*maxSize;
                double angle1 = random.NextDouble()*180;
                double angle2 = random.NextDouble() * (180 - angle1);
                double a = height / Math.Sin(angle1);
                double b = height / Math.Sin(angle2);
                double c = height / Math.Tan(angle1) + height/Math.Tan(angle2);
                return new Triangle(a,b,c);
            }else if(name.Equals("正方形"))
            {
                double size = random.NextDouble() * maxSize;
                return new Square(size);
            }else if (name.Equals("长方形"))
            {
                double height = random.NextDouble() * maxSize;
                double width = random.NextDouble() * maxSize;
                return new Rectangle(height,width);
            }
            return null;
        }
    }
    public class Project
    {
        public static void Main()
        {
            Shape shape;
            double sum = 0;
            string[] names = { "三角形", "正方形", "长方形" };
            for (int i = 0; i < 10; i++)
            {
                shape = ShapeFactory.getShape(names[i%3]);
                Console.WriteLine(shape.getArea());
                sum += shape.getArea();
            }
            Console.WriteLine("10个形状的面积为"+sum);
            Console.ReadKey();
        }
    }
}
