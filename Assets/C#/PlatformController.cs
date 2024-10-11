using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
     public static float speed = 3f;

    [SerializeField] private Rigidbody2D rb;


    void Update()
    {
       rb.velocity =  new Vector2 (-1 * speed, 0);
    }
}
