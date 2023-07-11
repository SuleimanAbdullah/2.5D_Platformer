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

    private void Update()
    {

        /*if (_isTargetB==false)
        {
            if (transform.position ==_pointB.position)
            {
                _isTargetB = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
            Debug.Log("Move PointA");
        }
        if (_isTargetB ==true)
        {
            if (transform.position == _pointA.position)
            {
                _isTargetB = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
            Debug.Log("Move PointB");
        }*/

        switch (_isTargetB)
        {
            case false:
                if (transform.position == _pointB.position)
                {
                    _isTargetB = true;
                }
                transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
                Debug.Log("Move PointA");
                break;

            case true:
                if (transform.position == _pointA.position)
                {
                    _isTargetB = false;
                }
                transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
                Debug.Log("Move PointB");
                break;
        }
    }

}
