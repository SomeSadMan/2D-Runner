using UnityEngine;

public class BonusGetter : MonoBehaviour
{
   private readonly float bonusValue = 3f;
   private Player player;

   private void OnCollisionEnter2D(Collision2D collider2D)
   {
      if (collider2D.gameObject.CompareTag("Player"))
      {
         player = FindObjectOfType<Player>();
         player.IsSpeedIncreased = true;
         player.JumpForce += bonusValue;
         Debug.Log($"bonus speed is added , your move speed is {player.JumpForce}");
         Destroy(gameObject);
      }
   }
}
