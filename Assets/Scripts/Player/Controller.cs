﻿using Assets.GameSystem.Constant;
using UnityEngine;
using UnityEngine.UI;
using GameSystem.Service;

namespace Player
{
    public class Controller : GameConstants
    {
        private bool isGrounded = false;
    
        Rigidbody m_rb;
    
        // Character Joystick Movement Variable
        private Transform m_Cam;
        private Vector3 m_CamForward;
        private Vector3 m_Move;
        Quaternion targetRotation;

        public bool m_Jump;
        private float verticalVelocity;
        public float HInput;
        public float VInput;

        void Update()
        {
            if(isGrounded && m_Jump && m_rb.velocity.y < 0.001f){
                isGrounded = false;;
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 400f);
            }
            else if (!isGrounded && m_Jump && m_rb.velocity.y < 0)
            {
                SetGravityScale(1f);
                verticalVelocity = GetGravityScale() * Time.deltaTime * 100f;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, -verticalVelocity, 0);
            }
        
            if(!m_Jump)
            {
                SetGravityScale(1f);
            }

            Data.Instance.starText.GetComponent<Text>().text = Data.Instance.starCounter.ToString();
        }
        void OnEnable ()
        {
            m_rb = GetComponent<Rigidbody>();
            m_rb.useGravity = false;
        }
 
        void FixedUpdate ()
        {
            Vector3 gravity = GetGlobalGravityScale() * GetGravityScale() * Vector3.up;
            m_rb.AddForce(gravity, ForceMode.Acceleration);

            // Character Movement
            if(null != m_Cam){
                // Calculate camera realative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = VInput * m_CamForward + HInput * m_Cam.right;
            }
            else{
                //we use world-relative directions in the case of no main camera
                m_Move = VInput * Vector3.forward + HInput * Vector3.right;
            }

            Vector3 targetDirection = new Vector3(HInput, 0f, VInput);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;

            if(0 != HInput  || 0f != VInput){
                targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            }

            this.transform.rotation = targetRotation;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * VInput * Time.deltaTime * GameConstants.MOVEMENT_SPEED;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * HInput * Time.deltaTime * GameConstants.MOVEMENT_SPEED;

        }

        private void OnCollisionEnter(Collision other) {
            if("Ground".Equals(other.gameObject.tag)){
                isGrounded = true;
            }
            else if ("Mushroom".Equals(other.gameObject.tag))
            {
                isGrounded = false;
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 12f, ForceMode.Impulse);
            }
            else if ("Mushroom-2".Equals(other.gameObject.tag))
            {
                isGrounded = false;
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 20f, ForceMode.Impulse);
            }
            else if ("Star".Equals(other.gameObject.tag))
            {
                Data.Instance.starCounter++;
                Destroy(other.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other) {
            //Kalo Pake Double Collider yang 1nya trigger
            // if ("Mushroom".Equals(other.gameObject.tag))
            // {
            //     isGrounded = false;
            //     this.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            // }
            if("Water".Equals(other.gameObject.tag)){
                if(null == EventService.LoadCheckPoint().XPos){
                    this.transform.position = new Vector3(46.51f, 1.83f, -0.07f);
                }
                else{
                    this.transform.position = new Vector3(EventService.LoadCheckPoint().XPos, EventService.LoadCheckPoint().YPos, EventService.LoadCheckPoint().ZPos);
                }
            }
        }
    }
}
