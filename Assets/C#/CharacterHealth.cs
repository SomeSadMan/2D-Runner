using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    private Player character;
    [SerializeField] private GameObject[] hpImage;
    private int hpValue = 3;
    internal readonly int takenDamage = 1;
    private int currentHeartIndex;

    public int HpValue
    {
        get => hpValue;
        set
        {
            if (value <= 0 )
            {
                character = FindObjectOfType<Player>();
                character.Die();
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
    
}
