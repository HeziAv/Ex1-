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
        private LinkedList<Func> funcComp;

        // Publisher
        public event EventHandler<double> OnCalculate;

        // Constructor
        public ComposedMission(string str)
        {
            this.funcName = str;
            this.funcComp = new LinkedList<Func>();
        }

        // Add a function to mission
        public ComposedMission Add(Func f)
        {
            if (f != null)
                this.funcComp.AddLast(f);
            return this; // for fluent programming
        }

        // This method runs the inner functions for calculation and calls the subscribers 
        public double Calculate(double value)
        {
            this.result = this.CalculateRecursively(this.funcComp.Last, value); // call method with the last node
            // if not null then invoke the function inside with the parameter 'result'
            OnCalculate?.Invoke(this, result); // Raise the event
            return this.result;
        }

        // This method calculates the functions recursively
        private double CalculateRecursively(LinkedListNode<Func> fNode, double val)
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