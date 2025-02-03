
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] backGrounds;
    [SerializeField] private Image shopImage;
    public int selectedBackGrounds = 0;


    private void Start()
    {
        
    }

    public void NextChoise()
    {
        backGrounds[selectedBackGrounds].SetActive(false);
        selectedBackGrounds = (selectedBackGrounds + 1) % backGrounds.Length;
        backGrounds[selectedBackGrounds].SetActive(true);
        Debug.Log($" вы перешли к   {selectedBackGrounds}");
        SaveSkin();
    }

    public void PreviousChoise()
    {
        backGrounds[selectedBackGrounds].SetActive(false);
        selectedBackGrounds--;
        if (selectedBackGrounds < 0)
        {
            selectedBackGrounds += backGrounds.Length;
        }
        backGrounds[selectedBackGrounds].SetActive(true);
        Debug.Log($" вы вернулись к  {selectedBackGrounds}");
        SaveSkin();
    }

    public void SaveSkin()
    {
        Debug.Log($"Попытка сохранить индекс: {selectedBackGrounds}");
        PlayerPrefs.SetInt("selectedBG", selectedBackGrounds);
        PlayerPrefs.Save();
        Debug.Log($"Фон сохранён: {PlayerPrefs.GetInt("selectedBG")}");
    }

    public void StartWithNewSkin()
    {
        PlayerPrefs.SetInt("selectedBG", selectedBackGrounds);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
