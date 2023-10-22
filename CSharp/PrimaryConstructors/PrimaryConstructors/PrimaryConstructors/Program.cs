public class NamedItem(string name)
{
    public string Name => name;
}

// name isn't captured in Widget.
// width, height, and depth are captured as private fields
public class Widget(string name, int width, int height, int depth) : NamedItem(name)
{
    public Widget() : this("N/A", 1, 1, 1) { } // unnamed unit cube

    public int WidthInCM => width;
    public int HeightInCM => height;
    public int DepthInCM => depth;

    public int Volume => width * height * depth;
}
