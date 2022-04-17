
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    public string currentLevel;


    public static CurrentLevel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de currentLevel dans la scène !");
        }

        else
        {
            instance = this;
        }
    }
}
