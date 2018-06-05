﻿
using Manager;
using UnityEngine;

namespace Delivery
{
    public interface I_Effect
    {
        void Apply(ToolManager owner, ToolManager target, bool ignoreOwner);
    }
}