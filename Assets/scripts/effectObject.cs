using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectObject : MonoBehaviour
{

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    
}
