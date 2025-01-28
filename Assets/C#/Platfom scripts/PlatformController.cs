using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] internal float speed = 3f;
    [SerializeField] internal float msxSpeed = 15f;
    [SerializeField] private Rigidbody2D rb;
    void FixedUpdate()
    {
       rb.velocity =  new Vector2 (-1 * speed, 0);
    }
}
