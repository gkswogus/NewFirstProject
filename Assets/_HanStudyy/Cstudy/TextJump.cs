using UnityEngine;

public class TextJump : MonoBehaviour
{
    public float height = 10f;      // 점프 높이
    public float speed = 3f;        // 점프 속도

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * height;

        transform.localPosition = startPos + new Vector3(0, y, 0);
    }
}