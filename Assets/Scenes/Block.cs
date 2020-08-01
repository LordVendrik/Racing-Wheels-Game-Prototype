using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wheel") {
            col.gameObject.GetComponent<NewBehaviourScript>().collided = 0;
            col.gameObject.GetComponent<NewBehaviourScript>().scaling = false;
            Debug.Log("Collided");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Wheel")
        {
            col.gameObject.GetComponent<NewBehaviourScript>().collided = 1;
            col.gameObject.GetComponent<NewBehaviourScript>().scaling = true;
            Debug.Log("recovered");
        }
    }
}
