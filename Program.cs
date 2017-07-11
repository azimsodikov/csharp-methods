using System;
using System.Collections.Generic;
using System.Linq;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            //So I called Bug method and passed the arguments it needed to feed the animals!
            Bug Predators = new Bug("Simba", "Limba", new List<string>() { "Bird"}, new List<string>{ "Meat"});
            Bug Prey = new Bug("Pumba", "Kimba", new List<string>() { "Bird"}, new List<string>{ "Meat"});
            Console.WriteLine(Predators.Eat("Meat"));
        }
    }
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name {  get;} = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName { get {return $"{this.Name} the {this.Species}";} }

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        // public string PreyList()
        // {
        //     var commaDelimitedPrey = string.Join(",", this.Prey);
        //     return commaDelimitedPrey;
        // }
        public string PreyList => string.Join(",", this.Prey);
        // Convert this method to an expression member
        // public string PredatorList()
        // {
        //     var commaDelimitedPredators = string.Join(",", this.Predators);
        //     return commaDelimitedPredators;
        // }
        public string PredatorList => string.Join(",", this.Predators);

        // Convert this to expression method (hint: use a C# ternary)
        public string Eat(string food) 
        {
            return (this.Prey.Contains(food)) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
        }
    }
}
