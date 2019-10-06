﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boulderBlock1;
    public GameObject boulderBlock2;

    // Update is called once per frame
    void Update()
    {
        //Cave 1 complete
        if(3 == Data.Instance.starCounter)
        {
            Destroy(boulderBlock1);
        }
        else if(6 == Data.Instance.starCounter)
        {
            Destroy(boulderBlock2);
        }
    }
}

