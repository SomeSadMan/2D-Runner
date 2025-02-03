using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBootStrap : MonoBehaviour
{
    private static bool _isInitialized;
    private void Awake()
    {
        if (_isInitialized)
        {
            Destroy(gameObject);
            return;
        }

        _isInitialized = true;
        DontDestroyOnLoad(gameObject);
    }
}
