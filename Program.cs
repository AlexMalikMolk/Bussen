namespace Bussen
{
    // Klass för att representera en passagerare med en specifik ålder.
    class Passagerare
    {
        public int Age { get; set; }

        public Passagerare(int age)
        {
            Age = age;
        }
    }

    // Klass för att representera bussen och dess funktioner.
    class Buss
    {
        private Passagerare[] passagerare = new Passagerare[50]; // Array för att lagra passagerare.
        private int antal_passagerare = 0;

        // Huvudmetod som kör programmet och visar menyn till användaren.
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear(); // Rensa skärmen innan menyn visas

                Console.WriteLine("Välkommen till Buss-simulatorn!");
                Console.WriteLine("1. Lägg till en passagerare");
                Console.WriteLine("2. Skriv ut alla passagerare");
                Console.WriteLine("3. Visa total ålder av alla passagerare");
                Console.WriteLine("4. Avsluta programmet");
                Console.Write("Välj ett alternativ: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            AddPassenger();
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 2:
                            PrintBuss();
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine($"Total ålder av alla passagerare: {TotalAge()}");
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Tack för att du använde Buss-simulatorn! Hejdå!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Console.WriteLine("Tryck på en tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }

        // Metod för att lägga till en passagerare till bussen.
        private void AddPassenger()
        {
            if (antal_passagerare < 50)
            {
                Console.Write("Ange ålder för passageraren: ");
                int age;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    passagerare[antal_passagerare] = new Passagerare(age);
                    antal_passagerare++;
                    Console.WriteLine("Passagerare tillagd!");
                }
                else
                {
                    Console.WriteLine("Ogiltig ålder. Försök igen.");
                }
            }
            else
            {
                Console.WriteLine("Bussen är full!");
            }
        }

        // Metod för att skriva ut åldern för alla passagerare på bussen.
        private void PrintBuss()
        {
            Console.WriteLine("Passagerares åldrar:");
            for (int i = 0; i < antal_passagerare; i++)
            {
                Console.WriteLine(passagerare[i].Age);
            }
        }

        // Metod för att beräkna den totala åldern av alla passagerare på bussen.
        private int TotalAge()
        {
            int totalAge = 0;
            for (int i = 0; i < antal_passagerare; i++)
            {
                totalAge += passagerare[i].Age;
            }
            return totalAge;
        }
    }

    // Huvudklass för att starta programmet.
    class Program
    {
        static void Main(string[] args)
        {
            var minbuss = new Buss();
            Console.Clear();
            minbuss.Run();
        }
    }
}
