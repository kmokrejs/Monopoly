public class Player {
    public int Position { get; set; } = 0; 
    public int Money { get; set; } = 10; 
    public bool InPrison { get; set; } = false;
    public int PrisonRolls { get; set; } = 0;
    public string Name {get; set; } = "Kuba";
    public List<Space> Properties { get; set; } = new List<Space>(); // Seznam vlastněných políček


    public void Move(int spaces, Board board) {
        int newPosition = (Position + spaces) % board.Spaces.Length;
        if (newPosition < Position) { 
            Money += 1; 
        }
        Position = newPosition;
    }

    public void MoveToPrison() {
        Position = 20; 
        InPrison = true;
        Console.WriteLine("\nJsi ve vězení!");
    }

    public void TryEscapePrison(int roll1, int roll2) {
        if (roll1 == roll2) {
            InPrison = false;
            PrisonRolls = 0; 
            Console.WriteLine("Hodil jsi dvojici! Unikl jsi z vězení.");
        } else {
            PrisonRolls++;
            if (PrisonRolls >= 3) {
                InPrison = false;
                PrisonRolls = 0; 
                Money -= 1; 
                Console.WriteLine("Neunikl jsi z vězení v 3 hodech. Platíš 1 a jdeš dál.");
            } else {
                Console.WriteLine($"Zůstáváš ve vězení. Máš {3 - PrisonRolls} pokusů.");
            }
        }
    }

    public void BuyProperty(PropertySpace property) {
        if (Money >= property.Price && property.Owner == null) {
            Money -= property.Price;
            property.Owner = this; // Nyní odkazujete na 'this', což je instance Player
            Properties.Add(property);
            Console.WriteLine($"\nKoupil jsi {property.Name} za {property.Price}. Peníze: {Money}");
        } else {
            Console.WriteLine("\nNemáš dost peněz na koupi této nemovitosti nebo je již vlastněna.");
        }
    }



}