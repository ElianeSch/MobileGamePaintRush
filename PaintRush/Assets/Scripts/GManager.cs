using UnityEngine;

public class GManager : MonoBehaviour
{

    public static GManager instance;
    public bool gameStarted = false;
    public GameObject tuto;

    private void Awake()
    {
        if (instance !=null)
        {
            Debug.Log("Plus d'une instance de GManager dans la scène !");
        }

        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            tuto.SetActive(false);
        }
    }

}
