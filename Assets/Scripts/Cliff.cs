using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    [SerializeField]
    private Transform _PlayerRespawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.isTrigger ==true)
        {
            Player player = other.transform.GetComponent<Player>();
            if (player !=null)
            {
                player.transform.position = _PlayerRespawnPoint.position;
                player.Damage();
                Debug.Log("OnTrigger Called");
            }
        }
    }
}
