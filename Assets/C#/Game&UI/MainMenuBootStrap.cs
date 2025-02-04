using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootStrap : MonoBehaviour
{
    [SerializeField] private Text coinAmountText;
    

    public int CoinsTotalAmount { get;  set; }
    
    private void Start()
    {
        CoinsTotalAmount = PlayerPrefs.GetInt("CoinValue", 0);
        UpdateCOinsUI();
    }

    public void UpdateCOinsUI()
    {
        coinAmountText.text = CoinsTotalAmount.ToString();
        PlayerPrefs.Save();
    }
}
