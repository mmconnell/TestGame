using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Manager
{
    public class Buffable : MonoBehaviour
    {
        public void Awake()
        {
            InformationManager.RegisterComponent(gameObject, typeof(Buffable), this);
        }

        public void OnDestroy()
        {
            InformationManager.UnRegisterComponent(gameObject, typeof(Buffable));
        }
    }
}
