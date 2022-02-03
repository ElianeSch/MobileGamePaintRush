using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;
    public float speed;
    public float posXmin; // Bornes pour le déplacement
    public float posXmax;


    private void Update()
    {
        if (Input.touchCount > 0) // Si le joueur a au moins un doigt sur l'écran
        {
            touch = Input.GetTouch(0); // On récupère les infos du premier doigt posé sur l'écran

            if (touch.phase == TouchPhase.Moved) // On regarde l'état du doigt qui touche l'écran : est-ce qu'il a bougé
            {
                // On bouge le cube en suivant le mouvement du doigt
                // Pour cela on ajoute à la position x la variation de la position du doigt multipliée par la vitesse

                // En vérifiant que le cube sera toujours entre nos deux bornes
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
