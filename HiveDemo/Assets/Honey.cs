using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x > 6 || transform.localPosition.z > 6f || transform.localPosition.z < -6f || transform.localPosition.x < -4.5f)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().drag = 0;
        }
    }
}
