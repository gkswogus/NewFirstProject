using UnityEngine;
using UnityEngine.UIElements;

public class SphereMaterialChange : MonoBehaviour
{
   public Renderer sphRnder;

    public Color nC = Color.white;
    public Color cC = Color.red;
    public GameObject gm;

    private Material sphMt;
    void Start()
    {
        sphMt = sphRnder.material;
    }

    void Update()
    {
        if (gm.transform.position.y < -6.3f)
        {
            sphMt.SetColor("_BaseColor", cC);      
        }
        else sphMt.SetColor("_BaseColor", nC);
    }
}
