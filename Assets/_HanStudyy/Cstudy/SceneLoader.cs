using Unity.AppUI.Redux;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   [SerializeField] private GameObject controlMenu;
    private bool isOn;
    private void Start()
    {
        if (controlMenu == null) return;
        controlMenu.SetActive(false);
        isOn = false;
    }
    public void OpenMenu()
    {
        if (!isOn)
        {
            controlMenu.SetActive(true);
            isOn=true;
        }
        else
        {
            controlMenu.SetActive(false);
            isOn = false;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
