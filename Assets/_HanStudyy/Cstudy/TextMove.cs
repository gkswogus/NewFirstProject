using UnityEngine;

public class TextMove : MonoBehaviour
{
    public float radius = 150f;  // 중심에서 떨어진 거리
    public float speed = 2f;     // 회전 속도

    private RectTransform rect;
    private float angle = 0f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        rect.anchoredPosition = new Vector2(x, y);
    }
}