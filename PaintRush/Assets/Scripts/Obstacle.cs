using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float speed;


    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
    }




}
