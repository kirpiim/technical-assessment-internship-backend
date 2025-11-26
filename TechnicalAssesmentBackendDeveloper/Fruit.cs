public class Fruit
{
    public string Name { get; set; }

    public Fruit(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

