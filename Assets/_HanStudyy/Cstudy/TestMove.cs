using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField] private float time = 0;
    [SerializeField] private int movePoint = 0;
    public float turnTime;
    public float rotY;
    public float moveSpeed;

    void Update()
    {
        // Translate만 사용 해서 이동 무한루프
        time += Time.deltaTime;

        if (time >= turnTime)
        {
            time = 0f;
            movePoint++;

            if (movePoint > 3) movePoint = 0;
        }

        switch (movePoint)
        {
            case 0:
                transform.Translate(Vector3.forward * Time.deltaTime * 4);
                break;
            case 1:
                transform.Translate(Vector3.left * Time.deltaTime * 4);
                break;
            case 2:
                transform.Translate(Vector3.back * Time.deltaTime * 4);
                break;
            case 3:
                transform.Translate(Vector3.right * Time.deltaTime * 4);
                break;
        }

        // Translate,Rotate를 사용 해서 이동 무한루프
        time += Time.deltaTime;
        if (time >= turnTime)
        {
            time = 0f;
            transform.Rotate(0, rotY, 0);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

}
