using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Hatches { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Hatches = new Dictionary<string, Room>();
        }

        public void Move (string direction, Room room)
         {
             Hatches.Add(direction, room);
         } 

        public void UseItem(Item item)
        {
           
        }
    }
}