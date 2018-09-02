using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class TimeManager : MonoBehaviour
    {
        private static TimeManager timeManager;
        public static TimeManager Instance
        {
            get
            {
                if (!timeManager)
                {
                    timeManager = FindObjectOfType(typeof(TimeManager)) as TimeManager;

                    if (!timeManager)
                    {
                        Debug.LogError("There needs to be one active InformationManager script on a GameObject in your scene.");
                    }
                    else
                    {
                        timeManager.Init();
                    }
                }

                return timeManager;
            }
        }

        private void Awake()
        {
            Instance.Init();
        }

        private void Update()
        {
            if (!paused)
            {
                for (int x = 0; x < listeners.Count; x++)
                {
                    if (!listeners[x].IsEnabled())
                    {
                        listeners[x].StopTracking();
                        listeners.RemoveAt(x);
                        x--;
                    }
                    else
                    {
                        listeners[x].Update(Time.deltaTime);
                    }
                }
            }
        }

        public static float GetDeltaTime()
        {
            if (Instance.paused)
            {
                return 0f;
            }
            return Time.deltaTime;
        }

        public static bool IsPaused()
        {
            return Instance.paused;
        }

        private List<I_Timed> listeners;
        private bool paused;

        void Init()
        {
            if (listeners == null)
            {
                listeners = new List<I_Timed>();
            }
        }

        public static void AddListener(I_Timed timed)
        {
            if (!timed.IsTracked())
            {
                timed.StartTracking();
                Instance.listeners.Add(timed);
            }
        }

        public void InstancePause()
        {
            Pause();
        }

        public static void Pause()
        {
            Instance.paused = !Instance.paused;
        }
    }
}
