
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGSelection : MonoBehaviour
{
    [SerializeField] private SkinStorage skinStorage;
    [SerializeField] private GameObject currentSelectedBg;
    [SerializeField] private Text priceText;

    private Renderer renderer;
    private int index;

    private void Start()
    {
        UpdateUiPriceText();
        renderer = currentSelectedBg.GetComponent<Renderer>();
        renderer.material = skinStorage.skinSettingsArray[index].material;
    }

    public void NextChoise()
    {
        index = (index + 1) % skinStorage.skinSettingsArray.Length;
        UpdateUiPriceText();
        renderer.material = skinStorage.skinSettingsArray[index].material;
        Debug.Log($" вы перешли к   {index}");
        SaveSkin();
    }

    public void PreviousChoise()
    {
        index--;
        if (index < 0)
        {
            index += skinStorage.skinSettingsArray.Length;
            renderer.material = skinStorage.skinSettingsArray[index].material;
            UpdateUiPriceText();
        }
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
        PlayerPrefs.SetInt("selectedBG", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void UpdateUiPriceText()
    {
        priceText.text = skinStorage.skinSettingsArray[index].price.ToString();
    }
}
