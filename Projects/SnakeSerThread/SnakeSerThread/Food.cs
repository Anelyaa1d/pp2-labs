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
    public class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;
        public Food()
        {
            FindPosition();
            sign = '@';
            color = ConsoleColor.DarkMagenta;
        }
        public void FindPosition()
        {
            int x = new Random().Next(0, 33);
            int y = new Random().Next(1, 33);
            location = new Point(x, y);

            if(FoodIsOnTheSnake() || FoodIsOnTheWall())
            {
                FindPosition();
            }
        }
        public bool FoodIsOnTheWall()
        {
            for (int i = 0; i < Game.wall.body.Count(); i++)
            {
                if (Game.wall.body[i].x == location.x && Game.wall.body[i].y == location.y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool FoodIsOnTheSnake()
        {
            for (int i = 0; i < Game.snake.body.Count(); i++)
            {
                if (Game.snake.body[i].x == location.x && Game.snake.body[i].y == location.y)
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }

}
