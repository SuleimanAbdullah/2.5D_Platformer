using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _coinText;

    [SerializeField]
    private TextMeshProUGUI _livesText;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is NULL: ");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _coinText = GetComponentInChildren<TextMeshProUGUI>();
        _instance = this;
    }
    void Start()
    {
        _coinText.text = "Coins: " + 0;
    }

    public void UpdatePlayerCoinsConsumed(int amount)
    {
        _coinText.text = "Coins: " + amount;
    }

    public void UPdateLivesText(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }
}
