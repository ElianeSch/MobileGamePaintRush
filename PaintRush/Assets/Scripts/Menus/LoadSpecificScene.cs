using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReturnToFirstMenu()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        SceneManager.MoveGameObjectToScene(GameManager, SceneManager.GetActiveScene());
        SceneManager.LoadScene("FirstMenu");
    }
}
