public class Board {
    public Space[] Spaces = new Space[40]; 

    public Board() {
        Spaces[0] = new StartSpace("Start");
        Spaces[1] = new PropertySpace("Vlněná", 2, "Brno");
        Spaces[2] = new PropertySpace("Orlí", 3, "Brno");
        Spaces[20] = new PrisonSpace("Vězenííí"); // nefunguje jeste
        for (int i = 3; i < Spaces.Length; i++) {
            Spaces[i] = new PropertySpace($"Políčko {i}", 0, "Ostatni");
        }
    }
}