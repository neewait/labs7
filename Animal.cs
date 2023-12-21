using System.Runtime.InteropServices.WindowsRuntime;

namespace Animal_
{
    
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class CustomCommentAttribute : System.Attribute
    {
        public string Comment { get; }

        public CustomCommentAttribute(string comment)
        {
            Comment = comment;
        }
    }
    
    [CustomComment("This is a comment for the Animal class.")]
    public abstract class Animal
    {
        public string Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public eClassificationAnimal WhatAnimal { get; set; }
    
        public Animal(string name, string country, bool hideFromOtherAnimals)
        {
            Name = name;
            Country = country;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }
        
        public abstract eClassificationAnimal GetClassificationAnimal();
        public abstract eFavouriteFood GetFavouriteFood();
        public virtual string SayHello()
        {
            return "Hello, I'm an animal.";
        }
        public virtual void Deconstruct() { }
    }

    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }
    
    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [CustomComment("This is a comment for the Cow class.")]
    public class Cow : Animal
    {
        public Cow(string name, string country, bool hideFromOtherAnimals) : base(name, country, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Herbivores;
        }
        
        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Plants;
        }
        
        public override eClassificationAnimal GetClassificationAnimal()
        {
            return WhatAnimal;
        }

        public override string SayHello()
        {
            return "Moo!";
        }
    }
    
    [CustomComment("This is a comment for the Lion class.")]
    public class Lion : Animal
    {
        public Lion(string name, string country, bool hideFromOtherAnimals) : base(name, country, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Carnivores;
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Meat;
        }

        public override string SayHello()
        {
            return "Roar!";
        }

        public override eClassificationAnimal GetClassificationAnimal() 
        {
            return WhatAnimal;
        }
    }
    
    [CustomComment("This is a comment for the Pig class.")]
    public class Pig : Animal
    {
        public Pig(string name, string country, bool hideFromOtherAnimals) : base(name, country, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Omnivores;
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Everything;
        }

        public override string SayHello()
        {
            return "Oink!";
        }

        public override eClassificationAnimal GetClassificationAnimal() 
        {
            return WhatAnimal;
        }
    }
}
