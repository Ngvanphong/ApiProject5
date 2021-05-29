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

        public const string Door = "Door";

        public const string Window = "Window";

        public const string Pile = "Foundation";
        
        public static List<string> ListCate { get { return new List<string> { Room,Door,Window, Pile }; } }
    }
}
