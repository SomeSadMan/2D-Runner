using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGSelection : MonoBehaviour
{
    [SerializeField] private SkinStorage skinStorage;
    [SerializeField] private GameObject currentSelectedBg;
    [SerializeField] private GameObject priceTextContainer;
    [SerializeField] private Text priceText;
    [SerializeField] private MainMenuBootStrap strap;

    

    private List<SkinSettings> existingSkins = new List<SkinSettings>();
    private Renderer renderer;
    internal int index;

    

    private void Start()
    {
        LoadExistingSkins();
        UpdateUiPriceText();
        renderer = currentSelectedBg.GetComponent<Renderer>();
        renderer.material = skinStorage.skinSettingsArray[index].material;
    }

    private void Update()
    {
        
    }

    public void NextChoise()
    {
        index = (index + 1) % skinStorage.skinSettingsArray.Length;
        renderer.material = skinStorage.skinSettingsArray[index].material;
        
        if (existingSkins.Contains(skinStorage.skinSettingsArray[index]))
        {
            priceTextContainer.SetActive(false);
        }
        else
        {
            priceTextContainer.SetActive(true);
        }
        UpdateUiPriceText();
        Debug.Log($" вы перешли к   {index}");
        SaveSkin();
    }

    public void PreviousChoise()
    {
        index--;
        if (index < 0)
        {
            index += skinStorage.skinSettingsArray.Length; 
        }
        if (existingSkins.Contains(skinStorage.skinSettingsArray[index]))
        {
            priceTextContainer.SetActive(false);
        }
        else
        {
            priceTextContainer.SetActive(true);
        }
        
        UpdateUiPriceText();
        renderer.material = skinStorage.skinSettingsArray[index].material;
        
        Debug.Log($" вы вернулись к  {skinStorage.skinSettingsArray.Length}");
        
        SaveSkin();
    }

    public void SaveSkin()
    {
        Debug.Log($"Попытка сохранить индекс: {index}");
        PlayerPrefs.SetInt("selectedBG", index);
        PlayerPrefs.Save();
        Debug.Log($"Фон сохранён: {PlayerPrefs.GetInt("selectedBG")}");
    }

    public void StartWithNewSkin()
    {
        if (existingSkins.Contains(skinStorage.skinSettingsArray[index]))
        {
            PlayerPrefs.SetInt("CoinValue", strap.CoinsTotalAmount);
            PlayerPrefs.SetInt("selectedBG", index);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else if (CanAfford())
        {
            strap.CoinsTotalAmount -= skinStorage.skinSettingsArray[index].price;
            existingSkins.Add(skinStorage.skinSettingsArray[index]);
            priceTextContainer.SetActive(false);
            PlayerPrefs.SetInt("CoinValue", strap.CoinsTotalAmount);
            PlayerPrefs.SetInt("selectedBG", index);
            SaveExistingSkins();
            strap.UpdateCOinsUI();
            UpdateUiPriceText();
            PlayerPrefs.Save();
            Debug.Log($"у вас осталось {strap.CoinsTotalAmount}");
            
        }
    }

    private void UpdateUiPriceText()
    {
        priceText.text = skinStorage.skinSettingsArray[index].price.ToString();
    }
    
    public bool CanAfford()
    {
        if (strap.CoinsTotalAmount >= skinStorage.skinSettingsArray[index].price)
        {
            Debug.Log($"вы купили новый фон под индексом {index}");
            return true;
        }
        else
        {
            Debug.Log($"у вас недостаточно денег на {index} ");
            return false;
        }

    }
    
    public void SaveExistingSkins() //метод сгенерирован нейронкой , разобрать его и понять как он работает 
    {
        List<int> boughtSkinIndices = new List<int>();

        foreach (var skin in existingSkins)
        {
            for (int i = 0; i < skinStorage.skinSettingsArray.Length; i++)
            {
                if (skinStorage.skinSettingsArray[i] == skin) // Сравниваем по ссылке
                {
                    boughtSkinIndices.Add(i);
                    break; // Нашли индекс — выходим из цикла
                }
            }
        }

        string serializedData = string.Join(",", boughtSkinIndices);
        PlayerPrefs.SetString("BoughtSkins", serializedData);
        PlayerPrefs.Save();

        Debug.Log($"Сохранены купленные скины: {serializedData}");
    }

    
    private void LoadExistingSkins()  //метод сгенерирован нейронкой , разобрать его и понять как он работает 
    {
        if (!PlayerPrefs.HasKey("BoughtSkins")) return;

        string serializedData = PlayerPrefs.GetString("BoughtSkins");
        string[] splitData = serializedData.Split(',');

        existingSkins.Clear();
        foreach (string indexStr in splitData)
        {
            if (int.TryParse(indexStr, out int index) && index >= 0 && index < skinStorage.skinSettingsArray.Length)
            {
                existingSkins.Add(skinStorage.skinSettingsArray[index]);
            }
        }

        Debug.Log($"Загружены купленные скины: {serializedData}");
    }


}
