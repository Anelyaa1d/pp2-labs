using System;
namespace Lab1
{
    public class CIrcle
    {
        public float Radius, Area, Length;
        public CIrcle()
        {
            Radius = 0;
            Area = 0;
            Length = 0;
        }
        public float FindArea(float r)
        {
            return Math.PI * r * r;
        }
        public float FindLength(float r)
        {
            return Math.PI * 2 * r;
        }
        public CIrcle(float r)
        {
            Radius = r;
            Area = FindArea(r);
            Length = FindLength(r);
        }
        public override string ToString()
        {
            return Radius + " " + Area + " " + Length;
        }
    }
}
