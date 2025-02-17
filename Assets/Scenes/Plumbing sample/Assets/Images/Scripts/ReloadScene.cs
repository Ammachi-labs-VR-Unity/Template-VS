using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void sceneload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}