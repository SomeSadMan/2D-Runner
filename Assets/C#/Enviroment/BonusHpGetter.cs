using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHpGetter : MonoBehaviour
{
   private CharacterHealth characterHp;
   private int bonusHpValue = 1;
   
   // private void OnCollisionEnter2D(Collision2D coll)
   // {
   //    if (coll.gameObject.CompareTag("PlayerOld"))
   //    {
   //       characterHp = FindObjectOfType<CharacterHealth>();
   //       characterHp.AddHeartInBar();
   //       characterHp.HpValue += bonusHpValue;
   //       
   //       Debug.Log($"HP is added , your hp is {characterHp.HpValue}");
   //       Destroy(gameObject);
   //    }
   // }
}
