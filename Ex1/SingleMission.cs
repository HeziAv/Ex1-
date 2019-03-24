using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class SingleMission : IMission
    {
        //SingleMission gets function and the name of the function and calculate it.
        Delegate1 func;
        string NameFunc;
        double resultFunc;

        public event EventHandler<double> OnCalculate;

        //the constructor
        public SingleMission(Delegate1 f, string str)
        {
            this.func = f;
            this.NameFunc = str;
        }


        string IMission.Type => "Single";
        string IMission.Name => this.NameFunc;


        //calculation of double to the function
        public double Calculate(double val)
        {
            this.resultFunc = this.func(val);
            OnCalculate?.Invoke(this, this.resultFunc);
            return resultFunc;
        }

        
    }
}