using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    // 'Func' is the delegate used in all classes
    public delegate double Func(double var);

    // This class represents Single Mission - only one function
    public class SingleMission : IMission
    {
        private Func func;
        private string funcName;
        private double result;

        // Publisher
        public event EventHandler<double> OnCalculate;

        // Constructor
        public SingleMission(Func f, string str)
        {
            this.func = f;
            this.funcName = str;
        }

        // This method runs the inner function for calculation and calls the subscribers 
        public double Calculate(double value)
        {
            this.result = this.func(value);
            // if not null then invoke the function inside with the parameter 'result'
            OnCalculate?.Invoke(this, this.result); // raise the event
            return this.result;
        }

        // Properties
        string IMission.Name => this.funcName;
        string IMission.Type => "Single";
    }
}