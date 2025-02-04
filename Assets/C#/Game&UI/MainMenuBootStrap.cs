using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootStrap : MonoBehaviour
{
    private static bool _isInitialized;

    [SerializeField] private Text coinAmountText;

    private int CoinsTotalAmount { get;  set; }
    
    private void Start()
    {
        CoinsTotalAmount = PlayerPrefs.GetInt("CoinValue", 0);
        coinAmountText.text = CoinsTotalAmount.ToString();
    }
}
