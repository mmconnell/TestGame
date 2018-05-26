using System;

public class TypeWrapper
{
    public Type type { get; private set; }

    public TypeWrapper(Type type)
    {
        this.type = type;
    }
}
