public class PropertySpace : Space {
    public int Price { get; set; }
    public Player? Owner { get; set; } = null;
    public string Group { get; set; }

    public string Name { get; set; }

    public PropertySpace(string name, int price, string group) : base(name) {
        Price = price;
        Group = group;
        Name = name;
    }

    public override void PerformAction(Player player) {
        if (Owner == null && player.Money >= Price && Name != "Políčko 20") {
            Console.WriteLine($"Chceš koupit {Name} za {Price}? (a/n)\n");
            var response = Console.ReadKey();
            if (response.Key == ConsoleKey.A) {
                player.BuyProperty(this);
            }
        } else if (Name == "Políčko 20"){
            Console.WriteLine("More ohni se pro to mydlo");
        } else {
            Console.WriteLine($"Toto políčko vlastní {Owner?.Name}. Musíš zaplatit nájemné.");
            // Přidat logiku pro placeni nájmu
        }
    }
}

public class StartSpace : Space {
    public StartSpace(string name) : base(name) {}

    public override void PerformAction(Player player) {
        Console.WriteLine("Prošel jsi startem. Získáváš 1.");
        player.Money += 1;
    }
}

public class PrisonSpace : Space {
    public PrisonSpace(string name) : base(name) {}

    public override void PerformAction(Player player) {
        Console.WriteLine("Jsi v base more.");
    }
}   
