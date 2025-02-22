using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundParalax : MonoBehaviour
{
    private Material material;
    private float distance;

    [Range(0f, 0.5f)] [SerializeField] private float speed;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    
    void Update()
    {
        Debug.Log($"Distance: {distance}, TextureOffset: {material.GetTextureOffset("_MainTex")}");
        distance += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * distance);
    }

    public void UpdateMaterial(Material newMaterial)
    {
        material = newMaterial;
    }
}
