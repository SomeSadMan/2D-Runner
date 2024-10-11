using UnityEngine;

public class Prlx : MonoBehaviour

    
{
    public float scrollSpeed = 0.5f; // Скорость прокрутки фона

    private float tileSizeX;
    private Vector3 startPosition;

    void Start()
    {
        tileSizeX = GetComponent<SpriteRenderer>().bounds.size.x; // Получаем ширину спрайта
        startPosition = transform.position; // Запоминаем начальную позицию объекта
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * -scrollSpeed, tileSizeX); // Рассчитываем новую позицию по оси X
        transform.position = startPosition + Vector3.right * newPosition; // Устанавливаем новую позицию объекта
    }
}
