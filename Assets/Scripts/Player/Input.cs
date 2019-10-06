using Cinemachine;
using GameSystem.Service;
using UnityEngine;

namespace Player
{
    public class Input : MonoBehaviour
    {
        public FixedJoystick LeftJoystick;
        public FixedButton JumpButton;
        public FixedTouchField SwipeCamera;
        protected Controller Controller;

        protected float CameraAngleX;
        protected float CameraAngleY;
        protected float CameraAngleSpeed = 0.01f;
        public float TouchSensitivity_x = 8f;
        public float TouchSensitivity_y = 8f;

        // Start is called before the first frame update
        void Start()
        {
            Controller = GetComponent<Controller>();
            CinemachineCore.GetInputAxis = GetAxisCustom;
        }

        // Update is called once per frame
        void Update()
        {
            if(PauseService.Instance.IsPaused()) return;
            Controller.m_Jump = JumpButton.Pressed;
            Controller.HInput = LeftJoystick.Horizontal;
            Controller.VInput = LeftJoystick.Vertical;

            CameraAngleX += -1 * SwipeCamera.TouchDist.x * CameraAngleSpeed;
            CameraAngleY += -1 * SwipeCamera.TouchDist.y * CameraAngleSpeed;
            if(0f == SwipeCamera.TouchDist.x){
                CameraAngleX = 0f;
            }
            if(0f == SwipeCamera.TouchDist.y){
                CameraAngleY = 0f;
            }
        }

        public float GetAxisCustom(string axisName)
        {
            if("Mouse X" == axisName)
            {
                return CameraAngleX;
            }
            else if("Mouse Y" == axisName)
            {
                return CameraAngleY;
            }
 
            return 0;
        }
    }
}
