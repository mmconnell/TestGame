using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TypeWrapper
{
    public Type type { get; private set; }

    public TypeWrapper(Type type)
    {
        this.type = type;
    }
}
