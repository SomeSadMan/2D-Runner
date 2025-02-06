using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ISaveAndLoad SaveManager;
    
    [SerializeField] internal GameObject priceTextContainer;
    [SerializeField] private BGSelection selector;
    [SerializeField] private Text priceText;
    [SerializeField] private Text coinAmountText;
    
    public int CoinsTotalAmount { get;  set; }
    
    internal List<SkinSettings> ExistingSkins = new List<SkinSettings>();
    internal int Index;
    
    public void Initialize(ISaveAndLoad save)
    {
        SaveManager = save;
    }

    private void Start()
    {
        LoadExistingSkins();
        UpdateCoinsUI();
        UpdateUiPriceText();
    }

    public void SaveSkin()
    {
        
        Debug.Log($"Попытка сохранить индекс: {Index}");
        PlayerPrefs.SetInt("selectedBG", Index);
        SaveExistingSkins();
        PlayerPrefs.Save();
        Debug.Log($"Фон сохранён: {PlayerPrefs.GetInt("selectedBG")}");
    }
    
    public void StartWithNewSkin() 
    {
        if (ExistingSkins.Contains(selector.skinStorage.skinSettingsArray[Index]))
        {
            SaveManager.Save(CoinsTotalAmount, Index);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else if (CanAfford())
        {
            CoinsTotalAmount -= selector.skinStorage.skinSettingsArray[Index].price;
            SaveManager.Save(CoinsTotalAmount, Index);
            ExistingSkins.Add(selector.skinStorage.skinSettingsArray[Index]);
            priceTextContainer.SetActive(false);
            SaveExistingSkins();
            UpdateCoinsUI();
            UpdateUiPriceText();
            Debug.Log($"у вас осталось {CoinsTotalAmount}");
        }
        else
        {
            Debug.Log("Недостаточно денег для покупки скина!");
        }
    }
    
    public void UpdateUiPriceText()
    {
        priceText.text = selector.skinStorage.skinSettingsArray[Index].price.ToString();
    }
    
    public bool CanAfford()
    {
        bool canAfford = CoinsTotalAmount >= selector.skinStorage.skinSettingsArray[Index].price;
        Debug.Log(canAfford ? $"вы купили новый фон под индексом {Index}" : $"у вас недостаточно денег на {Index}");
        return canAfford;
    }
    
    public void SaveExistingSkins()
    {
        List<int> boughtSkinIndices = new List<int>();

        foreach (var skin in ExistingSkins)
        {
            for (int i = 0; i < selector.skinStorage.skinSettingsArray.Length; i++)
            {
                if (selector.skinStorage.skinSettingsArray[i] == skin) //
                {
                    boughtSkinIndices.Add(i);
                    break;
                }
            }
        }

        string serializedData = string.Join(",", boughtSkinIndices);
        PlayerPrefs.SetString("BoughtSkins", serializedData);
        PlayerPrefs.Save();

        Debug.Log($"Сохранены купленные скины: {serializedData}");
    }
    
    private void LoadExistingSkins()
    {
        if (!PlayerPrefs.HasKey("BoughtSkins")) return;

        string serializedData = PlayerPrefs.GetString("BoughtSkins");
        string[] splitData = serializedData.Split(',');

        ExistingSkins.Clear();
        foreach (string indexStr in splitData)
        {
            if (int.TryParse(indexStr, out int index) && index >= 0 && index < selector.skinStorage.skinSettingsArray.Length)
            {
                ExistingSkins.Add(selector.skinStorage.skinSettingsArray[index]);
            }
        }

        Debug.Log($"Загружены купленные скины: {serializedData}");
    }
    public void UpdateCoinsUI()
    {
        CoinsTotalAmount = PlayerPrefs.GetInt("CoinValue", 0);
        coinAmountText.text = CoinsTotalAmount.ToString();
    }
    
}
