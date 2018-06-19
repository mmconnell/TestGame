using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public interface I_Timed
    {
        void Update(float time);
        bool IsEnabled();
        void StartTracking();
        void StopTracking();
        bool IsTracked();
    }
}
