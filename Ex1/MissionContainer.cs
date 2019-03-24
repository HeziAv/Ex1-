using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    // This class represents Functions Container - Dictionary of strings and functions
    // 'Func' is the delegate used in all classes
    public delegate double Delegate1(double d);
    public class FunctionsContainer
    {
        private Dictionary<string, Delegate1> dicmap;

        // Constructor
        public FunctionsContainer()
        {
            dicmap = new Dictionary<string, Delegate1>();
        }

        // This function returns a list of the dictionary keys
        public List<string> getAllMissions()
        {
          return new List<string>(this.dicmap.Keys); ;
        }

        // an Indexer for an instance of this class
        public Delegate1 this[string key]
        {
            get
            {
                if (!dicmap.ContainsKey(key))
                    dicmap[key] = value => value; // returns the value -> default of "stam" function
                return dicmap[key];
            }
            set
            {
                dicmap[key] = value;
            }
        }
    }
}