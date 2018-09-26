using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    //抽象图形父类：抽象产品类  
    public abstract class Shape 
    {
        private string myName;                    //图形

        public Shape(string s)
        {
            Name = s;
        }

        public string Name
        {
            get
            {
                return myName;
            }

            set
            {
                myName = value;
            }
        }

        public abstract double Area
        {
            get;
        }

        public override string ToString()
        {
            return Name + "Area = " + string.Format("{0:F2}", Area);
        }
    }

    //三角形类：具体产品类  
    public class Triangle : Shape
    {
        private int myHeight;
        private int myLength;

        public Triangle(int height,int length,string name):base(name)
        {
            myHeight = height;
            myLength = length;
        }

        public override double Area
        {
            get
            {
                return (myLength * myHeight) / 2;
            }
            
        }
    }  

    //圆形类：具体产品类  
    class Circle : Shape
    {
        private int myRadius;

        public Circle(int radius,string name):base(name)
        {
            myRadius = radius;
        }  

        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }  
    }  

    //正方形类：具体产品类  
    class Square : Shape
    {
        private int mySide;

        public Square(int side,string name):base(name)
        {
            mySide = side;
        }  

        public override double Area
        {
            get
            {
                return mySide * mySide;
            }
        }  
    }
    
    //长方形类：具体产品类
    class Rectangle : Shape
    {
        private int myLength;
        private int myWidth;

        public Rectangle(int length,int width,string name):base(name)
        {
            myLength = length;
            myWidth = width;
        }

        public override double Area
        {
            get
            {
                return myLength * myWidth;
            }
        }
    }

    //图表工厂类：工厂类  
    class ShapeFactory
    {
        //静态工厂方法  
        public static Shape GetShape(String type)
        {  
            Shape shape = null;
            if (type.Equals("triangle"))
            {  
                Console.WriteLine("请输入高度和底边长度：");
                int hei = Int32.Parse(Console.ReadLine());
                int len = Int32.Parse(Console.ReadLine());
                shape = new Triangle(hei, len, type);
            }  
            else if (type.Equals("circle"))
            {    
                Console.WriteLine("请输入半径：");
                int rad = Int32.Parse(Console.ReadLine());
                shape = new Circle(rad, type);
            }  
            else if (type.Equals("square"))
            {  
                Console.WriteLine("请输入边长：");
                int side = Int32.Parse(Console.ReadLine());
                shape = new Square(side, type);
            }
            else if (type.Equals("rectangle"))
            {
                Console.WriteLine("请输入长和宽：");
                int len = Int32.Parse(Console.ReadLine());
                int wid = Int32.Parse(Console.ReadLine());
                shape = new Rectangle(len, wid, type);
            }
            else
		    {
			    throw new Exception("对不起，没有该图形！");
		    }
            return shape;  
        }  
    }

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the shape name(triangle,circle,square,rectangle):");
            Shape shape;
            shape = ShapeFactory.GetShape(Console.ReadLine());
            Console.WriteLine(shape);
            Console.ReadLine();
        }
    }

}
