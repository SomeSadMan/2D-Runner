using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHpGetter : MonoBehaviour
{
   private CharacterHealth characterHp;
   private int bonusHpValue = 1;
   
   private void OnTriggerEnter2D(Collider2D coll)
   {
      if (coll.CompareTag("Player"))
      {
         characterHp = FindObjectOfType<CharacterHealth>();
         characterHp.AddHeartInBar();
         characterHp.HpValue += bonusHpValue;
         
         Debug.Log($"HP is added , your hp is {characterHp.HpValue}");
         Destroy(gameObject);
      }
   }
}
