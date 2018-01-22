using System;
namespace Lab1
{
    public class Rectangle
    {
        public float Height, Width, Area, Perimeter;
        public Rectangle()
        {
            Height = 0;
            Width = 0;
            Area = 0;
            Perimeter = 0;
        }
        public float FindArea(float h, float w )
        {
            return h * w;
        }
        public float FindPerimeter(float h,float w)
        {
            return (h + w) * 2;
        }
        public Rectangle(float h,float w)
        {
            Height = h;
            Width = w;
            Area = FindArea(h, w);
            Perimeter = FindPerimeter(h, w);
        }
        public override string ToString()
        {
            return Area + " " + Perimeter;
        }
    }
}
            
    
