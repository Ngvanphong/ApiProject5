using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject5.RenumberElement
{
  public static class Constants
    {
        public  const string Room = "Room";

        public const string Pile = "Pile";
        
        public static List<string> ListCate { get { return new List<string> { Room, Pile }; } }
    }
}
