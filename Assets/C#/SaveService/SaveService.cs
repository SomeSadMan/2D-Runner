using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveService : ISaveAndLoad
{
    public SaveService()
    {
        
    }
    public void Save(int value, int value2)
    {
        PlayerPrefs.SetInt("CoinValue", value);
        PlayerPrefs.SetInt("selectedBG", value2);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        PlayerPrefs.GetInt("CoinValue", 0);
        PlayerPrefs.GetInt("selectedBG", 0);
        
    }
}
