using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenExitShop : MonoBehaviour
{
    [SerializeField] private GameObject shopContainer;
    
    public void OpenShop()
    {
        shopContainer.SetActive(true);
        //SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


    public void ExitToMenu()
    {
        shopContainer.SetActive(false);
        //SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
