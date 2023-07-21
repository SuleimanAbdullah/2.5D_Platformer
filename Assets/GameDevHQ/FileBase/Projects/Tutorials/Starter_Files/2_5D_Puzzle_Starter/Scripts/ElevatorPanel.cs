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
    private void Awake()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (Input.GetKeyDown(KeyCode.E) && player.CointCount() >=_coinCollected)
            {
                _meshRenderer.material.color = Color.green;
                Elevator.IsGoingDown = true;
            }
           
        }
    }

    IEnumerator WaitBeforeGoingUp()
    {
        yield return new WaitForSeconds(2f);
        Elevator.IsGoingDown = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitBeforeGoingUp());
        }
    }
}
