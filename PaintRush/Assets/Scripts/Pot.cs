using UnityEngine;

public class Pot : MonoBehaviour
{

    public float speed;
    public int potId = 2;

    private void Update()
    {
        if (transform.tag == "Pot")
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed); //(0,0,-1) + calibration selon les fps de l'ordi utilisé, pour que la vitesse soit identique quel que soit l'ordi utilisé
        else if (transform.tag == "PotEau")
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Out")
        {
            Destroy(gameObject);
        }

    }
}
