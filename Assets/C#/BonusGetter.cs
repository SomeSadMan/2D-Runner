using UnityEngine;

public class BonusGetter : MonoBehaviour
{
   private readonly float bonusValue = 3f;
   [SerializeField] private Player player;

   private void OnTriggerEnter2D(Collider2D collider2D)
   {
      if (collider2D.CompareTag("Player"))
      {
         player.IsSpeedIncreased = true;
         player.JumpForce += bonusValue;
         Debug.Log($"bonus speed is added , your move speed is {player.JumpForce}");
         Destroy(gameObject);
      }
   }
}
