using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace SnakeSerThread
{
    [Serializable]
    public class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public Wall(int level)
        {
            body = new List<Point>();
            color = ConsoleColor.DarkRed;
            sign = '#';
            ReadLevel(Game.level);
        }
        public void ReadLevel(int level)
        {
            string cur = string.Format(@"C:/Users/anelbelgibaeva/Projects/SnakeSerThread/SnakeSerThread/levels/level1" + Game.level + ".txt");
            FileStream fs = new FileStream(cur, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int row = 0;
            string line = "";
            while (row < 50)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if(line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                row++;
            }
         }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
