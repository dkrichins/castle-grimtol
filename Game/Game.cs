using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; } 
        public List<Room> Rooms { get; set; }        
        public Boolean IsPlaying { get; set; }

         public void Setup()
        {
            Rooms = new List<Room>();
            CurrentPlayer = new Player();

            Room hatchL1 = new Room("Hatch L1", "Engine Room - Engine is on fire in this room, must get out quickly!!");
            Room hatchL2 = new Room("Hatch L2", "Radio room - nothing to grab, there is one hatch above your head, and one hatch in the forward direction");
            Room hatchL3 = new Room("Hatch L3", "Munitions room - nothing to grab, there is a hatch to the aft and a hatch in the forward direction");
            Room hatchL4 = new Room("Hatch L4", "Blackout room - you enter the room in pitch blackness. Luckily out of the corner of your eye you see a flashlight lying on the floor.");
            Room hatchU1 = new Room("Hatch U1", "Captains quarters - Locked");
            Room hatchU2 = new Room("Hatch U2", "Kitchen - Everything is in shambles, there is a hatch to the aft and a hatch in the forward direction.  There is a large overturned shelf blocking the forward hatch.  You see a large crowbar on the floor");
            Room hatchU3 = new Room("Hatch U3", "Crew quarters - nothing to grab, there there is one hatch at your feet, and one hatch in the forward direction");
            Room hatchU4 = new Room("Hatch U4", "Congratulations, you have made it to the escape hatch room.  You are going to be rescued!!!!");			

			hatchL1.Hatches.Add("up", hatchU1);
            hatchL1.Hatches.Add("forward", hatchL2);
			
			hatchL2.Hatches.Add("up", hatchU2);
            hatchL2.Hatches.Add("forward", hatchL3);
            hatchL2.Hatches.Add("aft", hatchL1);

			hatchU2.Hatches.Add("forward", hatchU3);
            hatchU2.Hatches.Add("aft", hatchU1);
            hatchU2.Hatches.Add("down", hatchL2);

			hatchU3.Hatches.Add("down", hatchL3);
            hatchU3.Hatches.Add("forward", hatchU4);
			hatchU3.Hatches.Add("aft", hatchU2);
            
			hatchL3.Hatches.Add("forward", hatchL4);
            hatchL3.Hatches.Add("aft", hatchL2);
			hatchL3.Hatches.Add("up", hatchU3);
            
            hatchL4.Hatches.Add("up", hatchU4);
            hatchL4.Hatches.Add("aft", hatchL3);
            hatchL4.Hatches.Add("forward", hatchL2);                      

			Item crowbar = new Item("Crowbar", "Use this item to move debris that might be blocking escape hatches.");
			hatchU2.Items.Add(crowbar);

			Item flashlight = new Item("Flashlight", "Use this to find your way in darkness");
			hatchL3.Items.Add(flashlight);
            
            Console.WriteLine(@"
            --SUBMARINE CHALLENGE--
            The alarm to abandoned submarine has begun to sound!!!
            You are a mechanic on a German Nazi U-boat that has
            just been struck by allied depth charges. Luckily, 
            your captain has just declared that you will be able
            to safely surface the vessel. However, as you are well 
            aware, an fire has started in the engine room on the lower
            deck and you must make your way to the front of the sub 
            where the escape hatch lies. The submarine iteself is comprised
            of an upper deck and a lower deck, each spanning four rooms or 
            hatches in length moving from the rear to the front of the sub.
            As you would on a real submarine, your movements will coordinate
            to nautical movements: i.e. north is Forward, south is Aft, east
            is Port,and west is Starboard.  You can also move up and down via 
            hatches between the upper and lower deck....good luck!!!!          
            ");

            Help();
        }

        public void Help()
        {
        System.Console.WriteLine(@"
            --HERE ARE THE RULES OF THE GAME--
            Move:  -Directions-i.e.,--Move Forward--Move Aft--Move Port--Move Starboard--Move Up--Move Down
			Survey: -Description of the hatch that you are currently in
            Grab: -Grab an Item-i.e.,--Grab wrench--Grab flashlight
            Inventory - shows you items in your inventory 
            Use: -Use an Item-i.e.,--Use wrench--Use flashlight
			Reset: - Restarts the game
            Quit - Ends the game
            ");
        }
        public void Reset()
        {
            IsPlaying = true;
            Console.Clear();
            Setup();
        }      
        public void UseItem(string itemName)
        {
            Item resultItem = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower()==itemName);
                    
        }
        public void Quit()
        {
            IsPlaying = false;
            Console.Clear();
        }
        public void Survey()
        {
            Console.WriteLine($"{CurrentRoom.Description}");
        }
        public void GrabItem(string itemName)
        {
            Item resultItem = CurrentRoom.Items.Find(Item => Item.Name == itemName);
        
            if (resultItem != null)
            {
                CurrentRoom.Items.Remove(resultItem);
                CurrentPlayer.Inventory.Add(resultItem);
            }
        }
        public void Inventory()
        {
            for(int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Item item = CurrentPlayer.Inventory[i];
                Console.WriteLine(item.Name);
            }
                
        }
    }
}