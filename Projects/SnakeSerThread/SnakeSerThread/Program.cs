using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeSerThread
{
    class Program
    {
     
            static void SerSnake(Snake snake)
            {
                FileStream fs = new FileStream(@"Snake.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Game.snake);
                fs.Close();
            }
            static Snake DeSerSnake()
            {
                FileStream fs = new FileStream(@"Snake.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                Game.snake = bf.Deserialize(fs) as Snake;
                fs.Close();
                return Game.snake;
            }

            static void SerWall(Wall wall)
            {
                FileStream fs = new FileStream(@"Wall.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Game.wall);
                fs.Close();
            }
            static Wall DeSerWall()
            {
                FileStream fs = new FileStream(@"Wall.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                Game.wall = bf.Deserialize(fs) as Wall;
                fs.Close();
                return Game.wall;
            }
            static void SerFood(Food food)
            {
                FileStream fs = new FileStream(@"Food.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Game.food);
                fs.Close();
            }
            static Food DeSerFood()
            {
                FileStream fs = new FileStream(@"Food.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                Game.food = bf.Deserialize(fs) as Food;
                fs.Close();
                return Game.food;
            }
            static void SerUsername(Username username)
            {
                FileStream fs = new FileStream(@"User.txt", FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Game.username);
                fs.Close();
            }
            static Username DeSerUsername()
            {
                FileStream fs = new FileStream(@"User.txt", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Game.username = bf.Deserialize(fs) as Username;
                fs.Close();
                return Game.username;
            }
            static void SnakeIsMoving()
            {
                while (!Game.Gameover)
                {
                    switch (Game.direction)
                    {
                        case 1:
                            Game.snake.Moves(0, -1);
                            break;
                        case 2:
                            Game.snake.Moves(0, 1);
                            break;
                        case 3:
                            Game.snake.Moves(-1, 0);
                            break;
                        case 4:
                            Game.snake.Moves(1, 0);
                            break;
                    }

                    Game.Draw();
                    Thread.Sleep(Game.GameSpeed);
                }
            }
            static string s;
            static void Main(string[] args)
            {

                Game.Init();
                Thread d = new Thread(SnakeIsMoving);
                // Console.WriteLine("Username:");
                while (true)
                {
                    ConsoleKeyInfo username = Console.ReadKey();
                    if (username.Key != ConsoleKey.Enter)
                    {
                        Console.WriteLine("Username:");
                        s = Console.ReadLine();
                    }
                    else if (username.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }

                Console.Clear();
                Console.WriteLine("if you want to start,please,press S");
                ConsoleKeyInfo key1 = Console.ReadKey();
                if (key1.Key == ConsoleKey.S)
                {

                    d.Start();
                }
            Game.username.username1 = s;
                while (!Game.Gameover)
                {
                    ConsoleKeyInfo btn = Console.ReadKey();
                    switch (btn.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Game.direction = 1;
                            break;
                        case ConsoleKey.DownArrow:
                            Game.direction = 2;
                            break;
                        case ConsoleKey.LeftArrow:
                            Game.direction = 3;
                            break;
                        case ConsoleKey.RightArrow:
                            Game.direction = 4;
                            break;
                        case ConsoleKey.X:
                            SerSnake(Game.snake);
                            SerFood(Game.food);
                            SerWall(Game.wall);
                            d.Suspend();
                            Console.Clear();
                            Console.SetCursorPosition(25, 25);
                            Console.WriteLine("Game is Stopped \n If you want to continue,please,press any button");
                            Console.ReadKey();
                            Console.Clear();
                            Game.snake = DeSerSnake();
                            Game.food = DeSerFood();
                            Game.wall = DeSerWall();
                            d.Resume();
                            break;
                        case ConsoleKey.Escape:
                            SerUsername(Game.username);
                            SerSnake(Game.snake);
                            SerFood(Game.food);
                            SerWall(Game.wall);
                            Console.Clear();
                            Console.WriteLine("You wanted to finish a Game");
                            Game.Gameover = true;
                            break;

                    }

                   

                    if (Game.snake.body[0].x > 49)
                    {
                        Game.snake.body[0].x = 0;
                    }
                    if (Game.snake.body[0].x < 0)
                    {
                        Game.snake.body[0].x = 49;
                    }
                    if (Game.snake.body[0].y > 49)
                    {
                        Game.snake.body[0].y = 1;
                    }
                    if (Game.snake.body[0].y < 1)
                    {
                        Game.snake.body[0].y = 49;
                    }

                }

            }

    }
}
