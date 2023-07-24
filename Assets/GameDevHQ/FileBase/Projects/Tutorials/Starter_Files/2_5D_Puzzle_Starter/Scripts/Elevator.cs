using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _targetPosA;
    [SerializeField]
    private Transform _targetPosB;

    private bool _isGoingDown = false;

    private void FixedUpdate()
    {
        if (_isGoingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosB.position
                , 3f * Time.deltaTime);
        }

        else if(_isGoingDown ==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosA.position
                , 3f * Time.deltaTime);
        }
    }

    public void CallElevator()
    {
        _isGoingDown = !_isGoingDown;
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
