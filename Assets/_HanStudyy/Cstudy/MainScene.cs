using UnityEngine;

public class MainScene : MonoBehaviour
{
   [SerializeField] private GameObject esc;
    private bool inOn;
    void Start()
    {
        esc.SetActive(false);
        inOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if(!inOn)
            {
                esc.SetActive(true);
                inOn = true;
            }
            else
            {
                esc.SetActive(false);
                inOn = false;
            }
        }
    }
}
