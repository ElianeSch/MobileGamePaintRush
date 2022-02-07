using UnityEngine;
using UnityEngine.SceneManagement;

public class PotSpawner : MonoBehaviour
{

    public Transform[] pos; // Les positions d'instantiation possibles pour les pots de peinture
    public Transform[] posDrops; // M�me chose pour les gouttes d'eau
    public int[] id; // La liste des id des pots, chaque id correspond � une couleur possible


    public float probabiliteSpawnEau;


    [SerializeField] private Pot potEau; // Objet pot d'eau, pour r�initialiser les slots et le pinceau
    private Pot newPotEau;

    public int spawnDelay;

    [SerializeField] private Pot pot;
    private Pot newPot;

    private bool hasSpawned = false;


    void Start()
    {

    }

    private void Update()
    {
        if (GManager.instance.gameStarted == true & !hasSpawned)
        {
            hasSpawned = true;
            InvokeRepeating("Spawn", 0.5f, spawnDelay); // Appelle � l'infini la fonction Spawn toutes les y secondes � partir de la x�me seconde de jeu

        }
    }

    public void Spawn()
    {

        float proba = Random.value;

        if (proba > probabiliteSpawnEau)
        {
            int potId = id[Random.Range(0, id.Length)]; // On choisit un id (et donc une couleur) au hasard parmi les id possibles

            newPot = Instantiate(pot, pos[Random.Range(0, pos.Length)].position, pot.transform.rotation); // On fait appara�tre un pot � une position al�atoire
            //int rotRandom = Random.Range(-180, 180);
            //newPot.transform.rotation = Quaternion.AngleAxis(rotRandom, new Vector3(0,0,1));
            GameObject SeauCouleur = newPot.transform.GetChild(0).gameObject;

            newPot.potId = potId; // On assigne au pot son id qu'on vient de choisir al�atoirement


            SeauCouleur.GetComponent<Renderer>().material.color = colorPot(potId);

        }

        else
        {
            newPotEau = Instantiate(potEau, posDrops[Random.Range(0, pos.Length)].position, Quaternion.identity); // On fait appara�tre un pot d'eau � une position al�atoire
        }
    }




    private Color colorPot(int potId)
    {
        Color couleur;
        if (potId == 2) // Si c'est du noir
            couleur = new Color(0f,0f,0f);
        else if (potId == 5) // Si c'est du jaune
            couleur = new Color(1.0f,1.0f,0f);
        else if (potId == 17) // Si c'est du magenta
            couleur = new Color(1.0f, 0f,1.0f);
        else if (potId == 65) // Si c'est du cyan
            couleur = new Color(0f,1.0f,1.0f);
        else
            couleur = new Color(Pinceau.instance.paletteRGB[potId, 0], Pinceau.instance.paletteRGB[potId, 1], Pinceau.instance.paletteRGB[potId, 2]);

        return couleur;

    }

}
