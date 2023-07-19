using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    [SerializeField]
    private float _speed = 1.5f;

    private bool _isTargetB;

    private void FixedUpdate()
    {
        switch (_isTargetB)
        {
            case false:
                if (transform.position == _pointB.position)
                {
                    _isTargetB = true;
                }
                transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
                break;

            case true:
                if (transform.position == _pointA.position)
                {
                    _isTargetB = false;
                }
                transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
               
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
