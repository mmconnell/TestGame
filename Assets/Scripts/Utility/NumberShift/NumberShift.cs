public class NumberShift
{
    public NumberShift()
    {
        Flat = 0;
        Scale = 1;
    }

    public float Flat { get; set; }
    public float Scale { get; set; }

    public int FlatInt()
    {
        return (int)Flat;
    }

    public int ScaleInt()
    {
        return (int)Scale;
    }
}
