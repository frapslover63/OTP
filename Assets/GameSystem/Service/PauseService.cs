using System;
using UnityEngine;

namespace GameSystem.Service
{
    public class PauseService : MonoBehaviour
    {
        public GameObject PauseCanvas;
        public static PauseService Instance;
        private bool Pause = false;
        private GameObject Canvas;
        private Transform Panel;

        private void Awake()
        {
            Canvas = Instantiate(PauseCanvas);
            Panel = Canvas.transform.GetChild(0);
            Instance = this;
            DontDestroyOnLoad(this);
        }

        public void PauseButtonTrigger()
        {
            if (IsPaused())
            {
                Pause = false;
            }
            else
            {
                Pause = true;
            }
            Panel.gameObject.SetActive(Pause);
        }

        public bool IsPaused()
        {
            return Pause;
        }
    }
}
