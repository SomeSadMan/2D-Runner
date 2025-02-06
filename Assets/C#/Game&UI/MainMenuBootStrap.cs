using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootStrap : MonoBehaviour
{
    private ISaveAndLoad saveManager;
    [SerializeField] private UIManager uiManager;
    
    private void Awake()
    {
        saveManager = new SaveService();
        uiManager.Initialize(saveManager);
    }
    

    
}
