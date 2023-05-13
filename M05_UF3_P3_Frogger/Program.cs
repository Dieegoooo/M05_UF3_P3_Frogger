using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace M05_UF3_P3_Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.Black, false, false, 0, ' ', null));
            List<ConsoleColor> colors2 = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Green };
            lanes.Add(new Lane(2, false, ConsoleColor.DarkCyan, false, true, 0.5f, '-', new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.Magenta }));
            lanes.Add(new Lane(4, true, ConsoleColor.Gray, true, false, 0.2f, 'O', new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.DarkRed }));
            List<ConsoleColor> colors4 = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Green };
            lanes.Add(new Lane(6, true, ConsoleColor.Black, false, false, 0.3f, '=', colors4));
            List<ConsoleColor> colors5 = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.DarkGreen };
            lanes.Add(new Lane(8, true, ConsoleColor.Black, true, true, 0.2f, 'X', colors5));
            //lanes.Add(new Lane(10, true, ConsoleColor.Black, false, false, 0, ' ', null));
            //List<ConsoleColor> colors7 = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow, ConsoleColor.Yellow, ConsoleColor.Yellow, ConsoleColor.DarkYellow };
            //lanes.Add(new Lane(12, false, ConsoleColor.Black, true, true, 0.15f, '*', colors7));
            lanes.Add(new Lane(14, false, ConsoleColor.Black, false, false, 0, ' ', null));
            List<ConsoleColor> colors9 = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow, ConsoleColor.Yellow, ConsoleColor.Yellow, ConsoleColor.DarkYellow };
            lanes.Add(new Lane(16, true, ConsoleColor.Black, true, true, 0.15f, '*', colors9));
            lanes.Add(new Lane(18, true, ConsoleColor.Black, false, false, 0, ' ', null));
            List<ConsoleColor> colors11 = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.DarkGreen };
            lanes.Add(new Lane(20, true, ConsoleColor.Black, true, true, 0.2f, 'X', colors11));
            lanes.Add(new Lane(22, false, ConsoleColor.Black, false, false, 0, ' ', null));
            List<ConsoleColor> colors13 = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Green };
            lanes.Add(new Lane(24, false, ConsoleColor.Black, false, false, 0.3f, '=', colors13));

            Player player = new Player();

            Utils.GAME_STATE state = Utils.GAME_STATE.RUNNING;
            while (state == Utils.GAME_STATE.RUNNING)
            {
                TimeManager.NextFrame();

                Console.Clear();

                player.Draw(lanes);
                state = player.Update(ReadInput(), lanes);
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                    lane.Draw();
                }

                Console.SetCursorPosition(0, Utils.MAP_HEIGHT + 1);
                Console.Write($"Time: {TimeManager.time.ToString("0.00")} s | Frame: {TimeManager.frameCount} | DeltaTime: {TimeManager.deltaTime.ToString("0.000")} s");

            }

            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(state == Utils.GAME_STATE.WIN ? "You win!" : "You lose :(");

            Console.ReadLine();
        }

        static Vector2Int ReadInput()
        {
            Vector2Int dir = Vector2Int.zero;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        dir = Vector2Int.up;
                        break;
                    case ConsoleKey.DownArrow:
                        dir = Vector2Int.down;
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = Vector2Int.left;
                        break;
                    case ConsoleKey.RightArrow:
                        dir = Vector2Int.right;
                        break;
                }
            }

            return dir;
        }
    }
}