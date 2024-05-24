using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pet creation - choosing a pet type and naming it
            Console.WriteLine("Please choose a type of pet: ");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Rabbit");

            int petTypeCode = int.Parse(Console.ReadLine());
            string petType = "";

            switch (petTypeCode)
            {
                case 1:
                    petType = "Dog";
                    break;
                case 2:
                    petType = "Cat";
                    break;
                case 3:
                    petType = "Rabbit";
                    break;
            }

            Console.WriteLine("You have selected: " + petType);
            Console.WriteLine("What would you like to name your pet?");
            string petName = Console.ReadLine();
            Console.WriteLine("Welcome, let's take good care of " + petName + ".");

            VirtualPet pet = new VirtualPet(petName, petType);

            while (true)
            {
            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Feed " + pet.Name);
            Console.WriteLine("2. Play with " + pet.Name);
            Console.WriteLine("3. Let " + pet.Name + " rest ");
            Console.WriteLine("4. Check " + pet.Name + "'s status");
            Console.WriteLine("5. Exit");
            int userActionCode = int.Parse(Console.ReadLine());
            string userActionName = "";
            switch (userActionCode)
            {
                case 1:
                    userActionName = "Feed " + pet.Name;
                    Console.WriteLine("You have selected: " + userActionName);
                    pet.Feed();
                    Console.WriteLine();
                    pet.CheckStatus();
                    break;
                case 2:
                    userActionName = "Play with " + pet.Name;
                    Console.WriteLine("You have selected: " + userActionName);
                    pet.Play();
                    Console.WriteLine();
                    pet.CheckStatus();
                    break;
                case 3:
                    userActionName = "Let " + pet.Name + " rest ";
                    Console.WriteLine("You have selected: " + userActionName);
                    pet.Rest();
                    Console.WriteLine();
                    pet.CheckStatus();
                    break;
                case 4:
                    userActionName = "Check " + pet.Name + "'s status";
                    Console.WriteLine("You have selected: " + userActionName);
                    Console.WriteLine(); 
                    pet.CheckStatus();
                    break;
                case 5:
                    userActionName = "Exit";
                    Console.WriteLine("You have selected: " + userActionName);
                    Console.WriteLine("Thank you for playing!");
                    return;
            }
        }
    }

        //Class with methods - Feed, Play, Rest, Status
        class VirtualPet
        {
            public string Name;
            public string Type;
            public int Hunger;
            public int Happiness;
            public int Health;

            // Constructor
            public VirtualPet(string name, string type)
            {
                Name = name;
                Type = type;
                Hunger = 5;
                Happiness = 5;
                Health = 5;
            }
            //Feed method
            public void Feed()
            {
                Hunger = Math.Max(Hunger - 2, 0);
                Health = Math.Min(Health + 1, 10);
                Console.WriteLine($"{Name} has been fed. Hunger decreased, Health increased slightly.");
            }

            //Play method
            public void Play()
            {
                if (Hunger >= 8)
                {
                    Console.WriteLine($"{Name} is too hungry to play!");
                }
                else
                {
                    Happiness = Math.Min(Happiness + 2, 10);
                    Hunger = Math.Min(Hunger + 1, 10);
                    Console.WriteLine($"{Name} played. Happiness increased, Hunger increased slightly.");
                }
            }
            //Rest method
            public void Rest()
            {
                Health = Math.Min(Health + 2, 10);
                Happiness = Math.Max(Happiness - 1, 0);
                Console.WriteLine($"{Name} is resting. Health increased, Happiness decreased slightly.");
            }
            //Check status
            public void CheckStatus()
            {
                Console.WriteLine($"Current status for: {Name}");
                Console.WriteLine($"Hunger: {Hunger}/10, Happiness: {Happiness}/10, Health: {Health}/10");
                CheckCriticalStatus();
            }

            // Check if any stat is critically low or high
            public void CheckCriticalStatus()
            {
                if (Hunger <= 2) Console.WriteLine($"{Name} is not so hungry!");
                if (Hunger >= 8) Console.WriteLine($"{Name} is very hungry!");
                if (Happiness <= 2) Console.WriteLine($"{Name} is very unhappy!");
                if (Happiness >= 8) Console.WriteLine($"{Name} is very happy!");
                if (Health <= 2) Console.WriteLine($"{Name} is very unhealthy!");
                if (Health >= 8) Console.WriteLine($"{Name} is in great health!");
            }
        }
    }
}
