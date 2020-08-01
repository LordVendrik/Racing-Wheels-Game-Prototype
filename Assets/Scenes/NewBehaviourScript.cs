using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    public float accel,force,expand,contract,speed,collided;
    bool decel = false;
    public bool scaling = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            decel = false;
            if (accel <= 4)
            {
                accel += 0.1f;
            }

            if (transform.localScale.x <= 2 && transform.localScale.z <= 2 && scaling)
            {
                transform.localScale += new Vector3(0.1f * expand, 0, 0.1f * expand);
            }
        }
        if (Input.touchCount == 0)
        {
            decel = true;
        }

        if (decel)
        {
            if (accel >= 0)
            {
                accel -= 0.01f;
            }
            if (transform.localScale.x >= 1.0f && transform.localScale.z >= 1.0f)
            {
                transform.localScale -= new Vector3(0.1f * contract, 0, 0.1f * contract);
            }
        }

        if (accel < 0) { accel = 0; }

        transform.Rotate(0,- accel * Time.deltaTime * force, 0);
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * accel * speed * collided);
    }
}
 