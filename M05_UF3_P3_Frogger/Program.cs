﻿using System;
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
            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(1, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, false, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, true, false, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, false, 0.1f, Utils.charLogs, Utils.colorsLogs.ToList()));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, false, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, false, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, Utils.colorsCars.ToList()));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0, Utils.charCars, Utils.colorsCars.ToList()));

            Player player = new Player();
            Vector2Int input = Input();

            Utils.GAME_STATE state = Utils.GAME_STATE.RUNNING;
            while (state == Utils.GAME_STATE.RUNNING)
            {

                state = player.Update(Utils.Input(), lanes);
                for (int i = 0; i < lanes.Count; i++)
                {
                    lanes[i].Update();
                }

                for (int i = 0; i < lanes.Count; i++)
                {
                    lanes[i].Draw();
                }
                player.Draw();

                if (state == Utils.GAME_STATE.WIN)
                {
                    Console.WriteLine("Has ganado");
                }

                if (state == Utils.GAME_STATE.LOOSE)
                {
                    Console.WriteLine("Has perdido");
                }
                TimeManager.NextFrame();
            }
            Console.ReadLine();
        }
    }
}