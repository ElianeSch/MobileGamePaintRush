using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;
    public float speed;
    public float posXmin; // Bornes pour le d�placement
    public float posXmax;


    private void Update()
    {
        if (Input.touchCount > 0) // Si le joueur a au moins un doigt sur l'�cran
        {
            touch = Input.GetTouch(0); // On r�cup�re les infos du premier doigt pos� sur l'�cran

            if (touch.phase == TouchPhase.Moved) // On regarde l'�tat du doigt qui touche l'�cran : est-ce qu'il a boug�
            {
                // On bouge le cube en suivant le mouvement du doigt
                // Pour cela on ajoute � la position x la variation de la position du doigt multipli�e par la vitesse

                // En v�rifiant que le cube sera toujours entre nos deux bornes
                float newX = transform.position.x + touch.deltaPosition.x * speed;
                if (newX > posXmax)
                    newX = posXmax;
                if (newX < posXmin)
                    newX = posXmin;

                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }

        }
    }



}
