using System;

public class NumberShift
{
    public NumberShift()
    {
        Flat = 0;
        Scale = 1;
    }

    public float Flat { get; set; }

    private float scale;
    public float Scale {
        get
        {
            return scale;
        }
        set
        {
            scale = Math.Abs(value);
        }
    }

    public int FlatInt()
    {
        return (int)Flat;
    }

    public int ScaleInt()
    {
        return (int)Scale;
    }
}
