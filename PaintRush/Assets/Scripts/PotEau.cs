using UnityEngine;

public class PotEau : MonoBehaviour
{

    public float speed;


    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed); //(0,0,-1) + calibration selon les fps de l'ordi utilisé, pour que la vitesse soit identique quel que soit l'ordi utilisé
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Out")
        {
            Destroy(gameObject);
        }

    }
}