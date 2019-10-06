using Cinemachine;
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
        protected float CameraAngleSpeed = 0.1f;
        public float TouchSensitivity_x = 10f;
        public float TouchSensitivity_y = 10f;

        // Start is called before the first frame update
        void Start()
        {
            Controller = GetComponent<Controller>();
            CinemachineCore.GetInputAxis = GetAxisCustom;
        }

        // Update is called once per frame
        void Update()
        {
            Controller.m_Jump = JumpButton.Pressed;
            Controller.HInput = LeftJoystick.Horizontal;
            Controller.VInput = LeftJoystick.Vertical;

            CameraAngleX += SwipeCamera.TouchDist.x * CameraAngleSpeed;
            CameraAngleY += SwipeCamera.TouchDist.y * CameraAngleSpeed;
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
