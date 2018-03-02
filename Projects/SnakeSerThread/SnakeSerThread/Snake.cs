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
    public class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(6, 6));
            sign = 'o';
            color = ConsoleColor.DarkBlue;
        }
        public void Moves(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;

            if (CollisionWithItself() || CollisionWithWall())
            {
                Console.Clear();
                Console.SetCursorPosition(19,19);
                Console.WriteLine("game over");
                Console.ReadKey();
                Game.snake = new Snake();
                Game.level = 1;
                Game.wall = new Wall(Game.level);
            }
            if (Eats())
            {
                Game.food.FindPosition();
                Game.counter++;
                Game.username.score = Game.counter;
                if(Game.counter % 5 == 0)
                {
                    Game.level++;
                    Game.GameSpeed -= 50;
                    Game.wall = new Wall(Game.level);
                }
            }
        }


        public bool Eats()
        {
            if(body[0].x == Game.food.location.x && body[0].y == Game.food.location.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }
            return false;
        }
        public bool CollisionWithWall()
        {
            foreach(Point p in Game.wall.body)
            {
                if(p.x == body[0].x && p.y == body[0].y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollisionWithItself()
        {
            for (int i = 1; i < body.Count(); i++)
            {
                if(body[i].x == body[0].x && body[i].y == body[0].y)
                {
                    return true;
                }
            }
            return false;
                
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Score:" + Game.counter);
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Level:" + Game.level + " " + "Username:" + Game.username.username1);
            Console.SetCursorPosition(0, 50);
            Console.WriteLine("if you want to stop, press S");

            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }
    }
}
