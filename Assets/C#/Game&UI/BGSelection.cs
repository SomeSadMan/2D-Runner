using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGSelection : MonoBehaviour
{
    [SerializeField] internal SkinStorage skinStorage;
    [SerializeField] private GameObject currentSelectedBg;
    [SerializeField] private UIManager uiManager;
    
    private Renderer renderer;
    
    private void Start()
    {
        
        renderer = currentSelectedBg.GetComponent<Renderer>();
        renderer.material = skinStorage.skinSettingsArray[uiManager.Index].material;
        uiManager.priceTextContainer.SetActive(!uiManager.ExistingSkins.Contains(skinStorage.skinSettingsArray[uiManager.Index]));
    }
    
    public void NextChoise()
    {
        uiManager.Index = (uiManager.Index + 1) % skinStorage.skinSettingsArray.Length;
        renderer.material = skinStorage.skinSettingsArray[uiManager.Index].material;

        if (uiManager.ExistingSkins.Contains(skinStorage.skinSettingsArray[uiManager.Index]))
        {
            uiManager.priceTextContainer.SetActive(false);
        }
        else
        {
            uiManager.priceTextContainer.SetActive(true);
        }

        uiManager.UpdateUiPriceText();
        Debug.Log($" вы перешли к   {uiManager.Index}");
        uiManager.SaveManager.Save(uiManager.Index, uiManager.CoinsTotalAmount);

    }

    public void PreviousChoise()
    {
        uiManager.Index--;
        if (uiManager.Index < 0)
        {
            uiManager.Index += skinStorage.skinSettingsArray.Length;
        }

        if (uiManager.ExistingSkins.Contains(skinStorage.skinSettingsArray[uiManager.Index]))
        {
            uiManager.priceTextContainer.SetActive(false);
        }
        else
        {
            uiManager.priceTextContainer.SetActive(true);
        }


        uiManager.UpdateUiPriceText();
        renderer.material = skinStorage.skinSettingsArray[uiManager.Index].material;

        Debug.Log($" вы вернулись к  {skinStorage.skinSettingsArray.Length}");

        uiManager.SaveManager.Save(uiManager.Index, uiManager.CoinsTotalAmount);
    }



}
