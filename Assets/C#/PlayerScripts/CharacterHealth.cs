using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterHealth :IHealth
{
    [SerializeField] private GameObject[] hpImage;
    private int hpValue = 3;
    internal readonly int takenDamage = 1;
    private int currentHeartIndex;
    private int currentHeartIndex2;

    public CharacterHealth(int hpValue)
    {
        _hpValue = hpValue;
    }

    public int _hpValue
    {
        get => hpValue;
        set
        {
            if (value <= 0)
            {
                
            }
            
            hpValue = value;
        }
    }

    public void HideHeartFromBar()
    {
        for (int i = currentHeartIndex; i < hpImage.Length;)
        {
            hpImage[i].SetActive(false);
            currentHeartIndex = i + 1;
            break;
        }
    }

    public void AddHeartInBar()
    {
        for (int i = hpImage.Length - 1; i >= 0; i--)
        {
            if (!hpImage[i].activeSelf) 
            {
                hpImage[i].SetActive(true); 
                break;
            }
        }

    }
}