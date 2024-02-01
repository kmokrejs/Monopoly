public class Game {
    private Board board = new Board();
    private Player player = new Player();

    public Game() {
        // Inicializace hry, např. vytvoření hráčů, herního plánu atd.
    }

    public void Start() {
        Console.WriteLine("Vítejte ve hře Monopoly!");

        while (true) {
            Console.WriteLine("\nStiskněte klávesu 'h' pro hod kostkou.\n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.H) {
                PerformRoll();
            }
        }
    }

    private void PerformRoll() {
        int roll1 = new Random().Next(1, 7);
        int roll2 = new Random().Next(1, 7);

        if (player.InPrison) {
            Console.WriteLine($"\nHodil jsi ve vězení: {roll1} a {roll2}");
            player.TryEscapePrison(roll1, roll2);        
        } else {
            if (roll1 == roll2) {
                player.MoveToPrison();
            } else {
                Console.WriteLine($"\nHodil jsi: {roll1} a {roll2}");
                player.Move(roll1 + roll2, board); 
            }
            InteractWithSpace();
        }
    }

    private void InteractWithSpace() {
        if (board.Spaces[player.Position] != null) {
            Space currentSpace = board.Spaces[player.Position];
            Console.WriteLine($"Stojíš na políčku {currentSpace.Name}. Peníze: {player.Money}");
            currentSpace.PerformAction(player);
        }
    }

}
