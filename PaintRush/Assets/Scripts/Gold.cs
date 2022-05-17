using UnityEngine;

public class Gold : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);   //(0,0,-1) + calibration selon les fps de l'ordi utilisé, pour que la vitesse soit identique quel que soit l'ordi utilisé
        transform.Rotate(Vector3.up, 100.0f * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Out"))
        {
            Destroy(gameObject);
        }

    }
}
