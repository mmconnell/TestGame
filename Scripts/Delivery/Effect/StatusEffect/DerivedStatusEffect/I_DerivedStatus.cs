using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery
{
    public interface I_DerivedStatus
    {
        void Enable();
        void Disable();
        void Remove();
        void Trigger(StatusEnum statusEnum);
        ToolManager Owner();
        ToolManager Target();
        I_DerivedStatus Clone(ToolManager owner, ToolManager target);
        void SetTicker(I_Ticker ticker);
    }
}
