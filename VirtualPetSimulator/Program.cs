using System;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pet creation - ask the user to choose a pet type
            Console.WriteLine("Please choose a type of pet: ");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Rabbit");

            //Capture user input
            int petTypeCode = int.Parse(Console.ReadLine());
            string petType = "";

            //Assign pet type based on user input
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

            //Ask the user to name the pet
            Console.WriteLine("What would you like to name your pet?");
            string petName = Console.ReadLine();
            Console.WriteLine("Welcome, let's take good care of " + petName + ".");

            VirtualPet pet = new VirtualPet(petName, petType);

            //Display Main Menu to user
            while (true)
            {
            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Feed " + pet.name);
            Console.WriteLine("2. Play with " + pet.name);
            Console.WriteLine("3. Let " + pet.name + " rest ");
            Console.WriteLine("4. Check " + pet.name + "'s status");
            Console.WriteLine("5. Exit");
            
            //Display mesasge based on user input and execute corresponding method from VirtualPet class
            int userActionCode = int.Parse(Console.ReadLine());
            string userActionName = "";
            switch (userActionCode)
            {
                case 1:
                    userActionName = "Feed " + pet.name;
                    Console.WriteLine("You have selected: " + userActionName);
                    pet.Feed();
                    Console.WriteLine();
                    break;
                case 2:
                    userActionName = "Play with " + pet.name;
                    Console.WriteLine("You have selected: " + userActionName);
                    pet.Play();
                    Console.WriteLine();
                    break;
                case 3:
                    userActionName = "Let " + pet.name + " rest ";
                    Console.WriteLine("You have selected: " + userActionName);
                    pet.Rest();
                    Console.WriteLine();
                    break;
                case 4:
                    userActionName = "Check " + pet.name + "'s status";
                    Console.WriteLine("You have selected: " + userActionName);
                    Console.WriteLine(); 
                    break;
                case 5:
                    userActionName = "Exit";
                    Console.WriteLine("You have selected: " + userActionName);
                    Console.WriteLine("Thank you for playing!");
                    return;
            }
                //Simulate time based changes after each action 
                pet.TimePassage();

                //Show current status after each action
                pet.CheckStatus();
        }
    }

        //Class with methods - Feed, Play, Rest, Status
        class VirtualPet
        {
            public string name;
            public string type;
            public int hunger;
            public int happiness;
            public int health;

            // Constructor
            public VirtualPet(string petName, string petType)
            {
                name = petName;
                type = petType;
                hunger = 5;
                happiness = 5;
                health = 5;
            }
            //Feed method
            public void Feed()
            {
                hunger = Math.Max(hunger - 2, 0);
                health = Math.Min(health + 1, 10);
                Console.WriteLine($"{name} has been fed. Hunger decreased, Health increased slightly.");
            }

            //Play method
            public void Play()
            {
                if (hunger >= 8)
                {
                    Console.WriteLine($"{name} is too hungry to play!");
                }
                else
                {
                    happiness = Math.Min(happiness + 2, 10);
                    hunger = Math.Min(hunger + 1, 10);
                    Console.WriteLine($"{name} played. Happiness increased, Hunger increased slightly.");
                }
            }
            //Rest method
            public void Rest()
            {
                health = Math.Min(health + 2, 10);
                happiness = Math.Max(happiness - 1, 0);
                Console.WriteLine($"{name} is resting. Health increased, Happiness decreased slightly.");
            }
            //Check status method
            public void CheckStatus()
            {
                Console.WriteLine($"Current status for: {name}");
                Console.WriteLine($"Hunger: {hunger}/10, Happiness: {happiness}/10, Health: {health}/10");
                CheckCriticalStatus();
            }

            //Check if any stat is critically low or high
            public void CheckCriticalStatus()
            {
                if (hunger <= 2) Console.WriteLine($"{name} is not so hungry!");
                if (hunger >= 8) Console.WriteLine($"{name} is very hungry!");
                if (happiness <= 2) Console.WriteLine($"{name} is very unhappy!");
                if (happiness >= 8) Console.WriteLine($"{name} is very happy!");
                if (health <= 2) Console.WriteLine($"{name} is very unhealthy!");
                if (health >= 8) Console.WriteLine($"{name} is in great health!");
            }

            //Time-based changes
            public void TimePassage()
            {
                hunger = Math.Min(hunger + 1, 10);
                happiness = Math.Max(happiness - 1, 0);
            }

        }
    }
}
