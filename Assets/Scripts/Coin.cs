using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_player !=null)
            {
                _player.AddCoin();
            }
            
        }
        Destroy(this.gameObject);
    }
}
