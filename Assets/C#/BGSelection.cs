using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGSelection : MonoBehaviour
{
    [SerializeField] private SkinStorage skinStorage;   //остается в скроллере
    [SerializeField] private GameObject currentSelectedBg;  //остается в скроллере
    [SerializeField] private GameObject priceTextContainer;     //уходит в UIManager
    [SerializeField] private Text priceText;                    //уходит в UIManager
    [SerializeField] private MainMenuBootStrap strap;           //уходит в UIManager (если это вообще нужно) 

    

    private List<SkinSettings> existingSkins = new List<SkinSettings>(); //остается в скроллере
    private Renderer renderer;  //остается в скроллере
    internal int index; //остается в скроллере

    

    private void Start()
    {
        LoadExistingSkins();
        UpdateUiPriceText();
        renderer = currentSelectedBg.GetComponent<Renderer>();
        renderer.material = skinStorage.skinSettingsArray[index].material;
        priceTextContainer.SetActive(!existingSkins.Contains(skinStorage.skinSettingsArray[index]));
    }

    private void Update()
    {
        
    }

    public void NextChoise()    //остается в скроллере
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

    public void PreviousChoise()    //остается в скроллере
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

    public void SaveSkin() //уходит в UIManager
    {
        Debug.Log($"Попытка сохранить индекс: {index}");
        PlayerPrefs.SetInt("selectedBG", index);
        PlayerPrefs.Save();
        Debug.Log($"Фон сохранён: {PlayerPrefs.GetInt("selectedBG")}");
    }

    public void StartWithNewSkin() //уходит в UIManager
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

    private void UpdateUiPriceText() //уходит в UIManager
    {
        priceText.text = skinStorage.skinSettingsArray[index].price.ToString();
    }
    
    public bool CanAfford() //уходит в UIManager
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
    
    public void SaveExistingSkins() //метод сгенерирован нейронкой , разобрать его и понять как он работает //уходит в UIManager
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

    
    private void LoadExistingSkins()  //метод сгенерирован нейронкой , разобрать его и понять как он работает  //уходит в UIManager
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
