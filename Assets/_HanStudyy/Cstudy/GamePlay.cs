using UnityEngine;

public class GamePlay : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 2f;

    private float minZ = -92f;
    private float maxZ = -88f;


 
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = Mathf.PingPong(Time.time* moveSpeed, maxZ-minZ)+minZ;
        transform.position = pos;

        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }
}
