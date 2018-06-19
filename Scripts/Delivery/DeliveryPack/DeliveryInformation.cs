using Manager;
using System.Collections.Generic;

namespace Delivery
{
    public struct DeliveryInformation
    {
        public Dictionary<ToolManager, DeliveryResultPack> packInfo;
        public I_Position currentPosition;
        public bool canTargetOwner;
    }
}
