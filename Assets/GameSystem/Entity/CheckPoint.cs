using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Entity
{
    [Serializable]
    public class CheckPoint
    {
        [SerializeField] private float xPos;
        [SerializeField] private float yPos;
        [SerializeField] private float zPos;
        [SerializeField] private float xRot;
        [SerializeField] private float yRot;
        [SerializeField] private float zRot;
        [SerializeField] private int starCount;
        [SerializeField] private float life;
        [SerializeField] private string level;

        public float XPos
        {
            get => xPos;
            set => xPos = value;
        }

        public float YPos
        {
            get => yPos;
            set => yPos = value;
        }

        public float ZPos
        {
            get => zPos;
            set => zPos = value;
        }

        public float XRot
        {
            get => xRot;
            set => xRot = value;
        }

        public float YRot
        {
            get => yRot;
            set => yRot = value;
        }

        public float ZRot
        {
            get => zRot;
            set => zRot = value;
        }

        public int StarCount
        {
            get => starCount;
            set => starCount = value;
        }

        public float Life
        {
            get => life;
            set => life = value;
        }

        public string Level
        {
            get => level;
            set => level = value;
        }
    }
}