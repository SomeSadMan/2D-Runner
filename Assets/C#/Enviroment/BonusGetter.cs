using UnityEngine;

public class BonusGetter : MonoBehaviour
{
   private readonly float bonusValue = 3f;
   private PlayerOld playerOld;

   private void OnCollisionEnter2D(Collision2D collider2D)
   {
      if (collider2D.gameObject.CompareTag("PlayerOld"))
      {
         playerOld = FindObjectOfType<PlayerOld>();
         playerOld.IsSpeedIncreased = true;
         playerOld.JumpForce += bonusValue;
         Debug.Log($"bonus speed is added , your move speed is {playerOld.JumpForce}");
         Destroy(gameObject);
      }
   }
}
