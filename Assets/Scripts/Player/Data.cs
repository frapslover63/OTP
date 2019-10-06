using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // Start is called before the first frame update
    public static Data Instance;
    public int starCounter;
    public GameObject starText;
    
    void Awake(){
        Instance = this;
        starCounter = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
