using System;
namespace SnakeSerThread
{
    [Serializable]
    public class Game
    {
        public static Snake snake;
        public static Food food;
        public static Wall wall;
        public static bool Gameover;
        public static int level;
        public static int counter;
        public static int direction;
        public static int GameSpeed;
        public static Username username;
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 20);
            Gameover = false;
            level = 1;
            counter = 0;
            GameSpeed = 250;
            wall = new Wall(level);
            snake = new Snake();
            food = new Food();
            username = new Username();
        }
        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(0, 50);
            Console.WriteLine("if you want to stop press S");
        }


    }
}
