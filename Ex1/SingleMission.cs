using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    // This class represents Single Mission - only one function
    public class SingleMission : IMission
    {
        Delegate1 func;
        string funcName;
        double result;

        // Publisher
        public event EventHandler<double> OnCalculate;

        // Constructor
        public SingleMission(Delegate1 f, string str)
        {
            this.func = f;
            this.funcName = str;
        }

        // This method runs the inner function for calculation and calls the subscribers 
        public double Calculate(double val)
        {
            this.result = this.func(val);
            // if not null then invoke the function inside with the parameter 'result'
            OnCalculate?.Invoke(this, this.result); // raise the event
            return result;
        }

        // Properties
        string IMission.Type => "Single";
        string IMission.Name => this.funcName;
    }
}