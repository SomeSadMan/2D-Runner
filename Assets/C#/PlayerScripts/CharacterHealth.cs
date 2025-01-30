using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterHealth :IHealth
{
    
    private GameObject[] hpImage;
    public event Action OnDeath;
    private int hpValue = 3;
    internal readonly int takenDamage = 1;
    private int currentHeartIndex;
    private int currentHeartIndex2;
    public bool IsPlayerAlive { get; set; } = true;

    public CharacterHealth(int hp, GameObject[] _hpImage )
    {
        HpValue = hp;
        hpImage = _hpImage;
    }

    public int HpValue
    {
        get => hpValue;
        set
        {
            hpValue = Mathf.Max(0, value);
            if (hpValue<= 0 )
            {
                OnDeath?.Invoke();
                IsPlayerAlive = false;

            }
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

    public void TakeDamage(int value)
    {
        HpValue -= value;
        Debug.Log($"хп стало меньше, ваше ХП {HpValue}");
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