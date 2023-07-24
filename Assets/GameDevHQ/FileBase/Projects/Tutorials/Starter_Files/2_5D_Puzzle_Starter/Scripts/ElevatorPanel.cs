using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private int _coinCollected;

    [SerializeField]
    private MeshRenderer _meshRenderer;

    private Elevator _elevator;

    private bool _isElevatorCalled = false;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (Input.GetKeyDown(KeyCode.E) && player.CointCount() >= _coinCollected)
            {
                _elevator.CallElevator();
                if (_isElevatorCalled == true)
                {
                    _meshRenderer.material.color = Color.red;
                }
                else 
                {
                    _meshRenderer.material.color = Color.green;
                    _isElevatorCalled = true;
                   
                }
            }
        }
    }
}
