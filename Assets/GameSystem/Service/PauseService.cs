using System;
using UnityEngine;

namespace GameSystem.Service
{
    public class PauseService : MonoBehaviour
    {
        public static PauseService Instance;
        private bool Pause = false;

        private void Awake()
        {
            Instance = this;
        }

        public void PauseGame()
        {
            Pause = true;
        }

        public void UnPauseGame()
        {
            Pause = false;
        }

        public bool IsPaused()
        {
            return Pause;
        }
    }
}
