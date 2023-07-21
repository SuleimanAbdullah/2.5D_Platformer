using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _targetPosA;
    [SerializeField]
    private Transform _targetPosB;

    public bool _isGoingDown;

    private void FixedUpdate()
    {
        if (_isGoingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosB.position
                , Time.deltaTime * 3f);
        }

        else if (_isGoingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosA.position
                , Time.deltaTime * 3);
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
