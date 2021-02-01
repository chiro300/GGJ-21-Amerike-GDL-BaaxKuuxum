using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeScenePress : MonoBehaviour
{
    public string scene = "Zona0";

    private void Awake()
    {
    }

    public void OnSubmit()
    {
        SceneManager.LoadScene(scene);
    }
}
