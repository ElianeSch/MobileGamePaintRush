using UnityEngine;

public class Pot : MonoBehaviour
{
    public float speed;
    public int potId;

    private float rotPot;

    private void Start()
    {
        rotPot = Random.Range(-180.0f, 180.0f);
    }
    private void Update()
    {

        if (PauseManager.gameIsPaused == false)
        {
           
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);   //(0,0,-1) + calibration selon les fps de l'ordi utilis?, pour que la vitesse soit identique quel que soit l'ordi utilis?
            transform.Rotate(Vector3.up, rotPot * Time.deltaTime, Space.World);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Out"))
        {
            Destroy(gameObject);
        }

    }
}
