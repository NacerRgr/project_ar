using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    // Method to load a scene by its name
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("first_scene");
    }
    public void QuitApplication()
    {
        Application.Quit();

    }
}

