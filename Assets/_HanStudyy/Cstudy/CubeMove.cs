using UnityEngine;

public class CubeMove : MonoBehaviour
{


    public float moveSpeed = 5.0f;
    void Update()
    {
        
        float moveZ = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.up*moveZ*moveSpeed*Time.deltaTime);
    }
}
