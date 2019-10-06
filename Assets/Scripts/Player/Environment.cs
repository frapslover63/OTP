using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boulderBlock1;

    // Update is called once per frame
    void Update()
    {
        //Cave 1 complete
        if(Data.Instance.starCounter == 3)
        {
            Destroy(boulderBlock1);
        }
    }
}

