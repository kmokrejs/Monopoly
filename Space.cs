public abstract class Space {
    public string Name { get; set; }
    public Space(string name) {
        Name = name;
    }
    public abstract void PerformAction(Player player);
}
