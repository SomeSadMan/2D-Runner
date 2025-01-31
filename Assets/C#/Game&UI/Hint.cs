using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private Animator animator;
    private GameManager gameManager;
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnHintDissapear += Dissapear;
    }
    
    private void Dissapear()
    {
        animator.SetTrigger("dis");
    }
}
