using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    // This class represents Composed Mission - one or more functions
    public class ComposedMission : IMission
    {
        private double result;
        private string funcName;
        private List<Delegate1> funcComp;

        // Publisher
        public event EventHandler<double> OnCalculate;

        // Constructor
        public ComposedMission(string str)
        {
            this.funcName = str;
            this.funcComp = new List<Delegate1>();
        }

        // Add a function to mission
        public ComposedMission Add(Delegate1 f)
        {
            if (f != null)
                this.funcComp.Add(f);
            return this; // for fluent programming
        }

        // This method runs the inner functions for calculation and calls the subscribers 
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
        
        // This method calculates the functions recursively
        private double CalculateRecursively(LinkedListNode<Delegate1> fNode, double val)
        {
            if (fNode.Previous == null) // if it is the first node
                return fNode.Value(val); // calculates function with val
            else
                return fNode.Value(this.CalculateRecursively(fNode.Previous, val));
        }

        // Properties
        string IMission.Name => this.funcName;
        string IMission.Type => "Composed";
    }
}