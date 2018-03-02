using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSerThread
{
    [Serializable]
    public class Username
    {
        public string username1;
        public int score;
        public Username()
        {
            username1 = "new user";
            score = 0;
        }
    }
}