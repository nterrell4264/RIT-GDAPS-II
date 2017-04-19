using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoork
{
    class AdjacencyList
    {
        public Dictionary<string, List<string>> rooms;

        public AdjacencyList()
        {
            rooms = new Dictionary<string, List<string>>();
        }

        public List<string> GetAdjacentList(string room)
        {
            return rooms[room];
        }

        public bool IsConnected(string room1, string room2)
        {
            foreach(string linkedRoom in GetAdjacentList(room1))
            {
                if (linkedRoom.Equals(room2)) return true;
            }
            foreach (string linkedRoom in GetAdjacentList(room2))
            {
                if (linkedRoom.Equals(room1)) return true;
            }
            return false;
        }
    }
}
