using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void Scene1Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void InvokeScene1Load()
    {
        Invoke("Scene1Load", 0.5f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void InvokeExitToMenu()
    {
        Invoke("ExitToMenu", 0.5f);
    }



}
