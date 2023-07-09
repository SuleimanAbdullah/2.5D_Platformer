using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI _coinText;
    
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance ==null)
            {
                Debug.LogError("UIManager is NULL: ");
            }
            return _instance;
        }
    }

    private void Awake()
    {
       _coinText = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        _coinText.text = "Coins: " + 0;
        _instance = this;
    }

    public void UpdatePlayerCoinsConsumed(int amount)
    {
        _coinText.text = "Coins: " + amount;
    }
}
