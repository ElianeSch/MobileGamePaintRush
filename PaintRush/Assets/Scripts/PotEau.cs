using UnityEngine;

public class PotEau : MonoBehaviour
{

    public float speed;


    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed); //(0,0,-1) + calibration selon les fps de l'ordi utilis�, pour que la vitesse soit identique quel que soit l'ordi utilis�
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Out")
        {
            Destroy(gameObject);
        }

    }
}