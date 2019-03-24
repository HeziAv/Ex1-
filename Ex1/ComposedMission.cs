using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private double result;
        private string funcName;
        private List<Delegate1> funcComp;

        public event EventHandler<double> OnCalculate;

       //constructor
        public ComposedMission(string str)
        {
            this.funcName = str;
            this.funcComp = new List<Delegate1>();
        }
        //adds a function
        public ComposedMission Add(Delegate1 f)
        {
            this.funcComp.Add(f);
            return this; 
        }
        //calculate all the functions
        public double Calculate(double value)
        {
            double result = value;
            foreach (Delegate1 f in funcComp)
            {
                result = f(result);
            }
            OnCalculate?.Invoke(this, result);
            return result;
        }
        
   
        // Properties
        string IMission.Name => this.funcName;
        string IMission.Type => "Composed";
    }
}