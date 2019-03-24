using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    // This class represents Functions Container - Dictionary of strings and functions
    public class FunctionsContainer
    {
        private Dictionary<string, Func> dict;

        // Constructor
        public FunctionsContainer()
        {
            this.dict = new Dictionary<string, Func>();
        }

        // This function returns a list of the dictionary keys
        public List<string> getAllMissions()
        {
            List<string> funcList = new List<string>(this.dict.Keys);
            return funcList;
        }

        // an Indexer for an instance of this class
        public Func this[string str]
        {
            get
            {
                if (!dict.ContainsKey(str))
                    dict[str] = value => value; // returns the value -> default of "stam" function
                return dict[str];
            }
            set
            {
                dict[str] = value;
            }
        }
    }
}