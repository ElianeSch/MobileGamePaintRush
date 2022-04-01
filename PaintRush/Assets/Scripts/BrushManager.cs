using UnityEngine;

public class BrushManager : MonoBehaviour
{

    public static BrushManager instance;

    public Brush brush;
    public int indexOfCurrentPixel;
 


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de BrushManager dans la scène !!!");
        }

        instance = this;


    }




    public void ManageCollisionWithPot(int potId)
    {

    }
    public void ManageCollisionWithWater()
    {

    }




}