using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using static M05_UF3_P3_Frogger.Utils;
using static M05_UF3_P3_Frogger.Element;

namespace M05_UF3_P3_Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(1, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charCars, Utils.colorsCars.ToList()));

            Player player = new Player();
      
            Vector2Int input = Input();

            Utils.GAME_STATE state = Utils.GAME_STATE.RUNNING;
            while (state == Utils.GAME_STATE.RUNNING)
            {
                TimeManager.NextFrame();

                player.Draw(lanes);
                state = player.Update(Utils.Input(), lanes);
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                    lane.Draw();
                }

                //Console.SetCursorPosition(0, Utils.MAP_HEIGHT + 1);
                Console.Write($"Time: {TimeManager.time.ToString("0.00")} s | Frame: {TimeManager.frameCount} | DeltaTime: {TimeManager.deltaTime.ToString("0.000")} s");

            }
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine(state == Utils.GAME_STATE.WIN ? "You win!" : "You lose :(");
            Console.ReadLine();
        }
    }
}