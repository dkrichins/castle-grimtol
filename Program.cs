using System;
using CastleGrimtol.Game;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game.Game game = new Game.Game();
            game.IsPlaying = true;
            game.Setup();
            game.Help();

            while(game.IsPlaying)
            {
                string userChoice = Console.ReadLine().ToLower();
                string[] userAction = userChoice.Split(' '); 
                Room nextRoom;
                
                if(userAction[0]=="survey")
                {
                    game.Survey();
                }
                else if(userAction[0]=="grab")
                {
                    game.GrabItem(userAction[1]);
                }
                else if(userAction[0]=="Investory")
                {
                    game.Inventory();
                }
                else if(userAction[0]=="use")
                {
                    game.UseItem(userAction[1]);   
                }
                else if(userAction[0]=="reset")
                {
                    game.Reset();
                }
                else if(userAction[0]=="quit")
                {
                    game.Quit();
                }
                else if (nextRoom != null)
                {
                game.CurrentRoom = nextRoom;
                
                }
                else
                {
                
                System.Console.WriteLine("You have attempted an unrecognized command.  Please try again.");
                
                }

            }

        }
    }
}
