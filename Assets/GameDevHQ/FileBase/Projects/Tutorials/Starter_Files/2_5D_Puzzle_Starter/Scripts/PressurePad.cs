using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _Display;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag =="MovingBox")
        {
            Rigidbody rb = other.transform.GetComponent<Rigidbody>();
            if(rb !=null)
            {
                if (other.transform.position.x <=  0.35f)
                {
                    rb.isKinematic = true;
                }
            }
            _Display.material.color = Color.blue;
        }
    }
}
