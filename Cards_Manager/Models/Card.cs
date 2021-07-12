using System;
using System.Collections.Generic;

namespace Cards_Manager.Models
{
    public class Card
    {
       /*public enum Type
        {
            VISA,
            Ticked,
            MasterCard
        }
       */
        public string Type { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        //public List<string> Type = new List<string>(); 
        

        
    }
}
