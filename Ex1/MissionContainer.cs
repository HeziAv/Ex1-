using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    //this delegate to use in all the program
    public delegate double Delegate1(double d);

    //the class that stores the diccionary from string
    public class FunctionsContainer
    {
        private Dictionary<string, Delegate1> dicmap;

        public FunctionsContainer()
        {
            dicmap = new Dictionary<string, Delegate1>();
        }

        public List<string> getAllMissions()
        {
            //list of keys
          return new List<string>(this.dicmap.Keys); ;
        }

        public Delegate1 this[string key]
        {
            //getter
            get
            {
                if (!dicmap.ContainsKey(key))
                    dicmap[key] = value => value; 
                return dicmap[key];
            }
            //setter
            set
            {
                dicmap[key] = value;
            }
        }
    }
}