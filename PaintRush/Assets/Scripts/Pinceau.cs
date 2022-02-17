using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using TMPro;

public class Pinceau : MonoBehaviour
{

    public int slotsOccupes = 0;
    public int maxSlotsOccupes;

    public int clePot1 = 1;
    public int clePot = 1; // dernier pot


    public int indexOfCurrentPixel = 0;
    public List<int> listeIndexOfPixelsHidden;

    public ColorBar colorBarMagenta;
    public ColorBar colorBarCyan;
    public ColorBar colorBarJaune;
    public ColorBar colorBarNoir;

    public int numberPotsMagenta = 0;
    public int[] idAtteignablesMagenta;

    public int numberPotsCyan = 0;
    public int[] idAtteignablesCyan;

    public int numberPotsJaune = 0;
    public int[] idAtteignablesJaune;

    public int numberPotsNoir = 0;
    public int[] idAtteignablesNoir;


    public GameObject[] currentColorC;
    public GameObject[] currentColorM;
    public GameObject[] currentColorJ;
    public GameObject[] currentColorN;

    public GameObject PanelGoutteEau;
    public Button boutonC;
    public Button boutonM;
    public Button boutonJ;
    public Button boutonN;

    public Color targetColor;

    public static Pinceau instance;

    public GameObject panelRecette4;
    public GameObject panelRecette3;
    public GameObject panelRecette2;
    public GameObject panelRecette1;

    public Image[] imagesSplashPanel1;
    public Image[] imagesSplashPanel2;
    public Image[] imagesSplashPanel3;
    public Image[] imagesSplashPanel4;

    public TextMeshProUGUI[] textesSplash1;
    public TextMeshProUGUI[] textesSplash2;
    public TextMeshProUGUI[] textesSplash3;
    public TextMeshProUGUI[] textesSplash4;
    public GameObject[] imagesPlus;

    public GameObject[] currentColorBarImages;

    public int currentColorBar = 0;

    public bool unveil = false;
    
    public float[,] paletteRGB = new float[,] { { 255.0000f, 255.0000f, 255.0000f}, { 170.8500f, 170.8500f, 170.8500f }, { 86.7000f, 86.7000f, 86.7000f }, { 0, 0, 0 }, { 255.0000f, 255.0000f, 170.8500f }, { 170.8500f, 170.8500f, 114.4695f},
    {86.7000f, 86.7000f, 58.0890f}, {0, 0, 0}, {255.0000f, 255.0000f, 86.7000f}, {170.8500f, 170.8500f, 58.0890f}, {86.7000f, 86.7000f, 29.4780f}, {0, 0, 0}, {255.0000f, 255.0000f, 0}, {170.8500f, 170.8500f, 0}, {86.7000f, 86.7000f, 0}, {0, 0, 0}, {255.0000f, 170.8500f, 255.0000f},
    {170.8500f, 114.4695f, 170.8500f}, {86.7000f, 58.0890f, 86.7000f}, {0, 0, 0}, {255.0000f, 170.8500f, 170.8500f}, {170.8500f, 114.4695f, 114.4695f}, {86.7000f, 58.0890f, 58.0890f}, {0, 0, 0}, {255.0000f, 170.8500f, 86.7000f}, {170.8500f, 114.4695f, 58.0890f},
    {86.7000f, 58.0890f, 29.4780f}, {0, 0, 0}, {255.0000f, 170.8500f, 0}, {170.8500f, 114.4695f, 0}, {86.7000f, 58.0890f, 0}, {0, 0, 0}, {255.0000f, 86.7000f, 255.0000f}, {170.8500f, 58.0890f, 170.8500f}, {86.7000f, 29.4780f, 86.7000f}, {0, 0, 0},
    {255.0000f, 86.7000f, 170.8500f}, {170.8500f, 58.0890f, 114.4695f}, {86.7000f, 29.4780f, 58.0890f}, {0, 0, 0}, {255.0000f, 86.7000f, 86.7000f}, {170.8500f, 58.0890f, 58.0890f}, {86.7000f, 29.4780f, 29.4780f}, {0, 0, 0}, {255.0000f, 86.7000f, 0},
    {170.8500f, 58.0890f, 0}, {86.7000f, 29.4780f, 0}, {0, 0, 0}, {255.0000f, 0, 255.0000f}, {170.8500f, 0, 170.8500f}, {86.7000f, 0, 86.7000f}, {0, 0, 0}, {255.0000f, 0, 170.8500f}, {170.8500f, 0, 114.4695f}, {86.7000f, 0, 58.0890f}, {0, 0, 0},
    {255.0000f, 0, 86.7000f}, {170.8500f, 0, 58.0890f}, {86.7000f, 0, 29.4780f}, {0, 0, 0}, {255.0000f, 0, 0}, {170.8500f, 0, 0}, {86.7000f, 0, 0}, {0, 0, 0}, {170.8500f, 255.0000f, 255.0000f}, {114.4695f, 170.8500f, 170.8500f}, {58.0890f, 86.7000f, 86.7000f},
    {0, 0, 0}, {170.8500f, 255.0000f, 170.8500f}, {114.4695f, 170.8500f, 114.4695f}, {58.0890f, 86.7000f, 58.0890f}, {0, 0, 0}, {170.8500f, 255.0000f, 86.7000f}, {114.4695f, 170.8500f, 58.0890f}, {58.0890f, 86.7000f, 29.4780f}, {0, 0, 0},
    {170.8500f, 255.0000f, 0}, {114.4695f, 170.8500f, 0}, {58.0890f, 86.7000f, 0}, {0, 0, 0}, {170.8500f, 170.8500f, 255.0000f}, {114.4695f, 114.4695f, 170.8500f}, {58.0890f, 58.0890f, 86.7000f}, {0, 0, 0}, {170.8500f, 170.8500f, 170.8500f},
    {114.4695f, 114.4695f, 114.4695f}, {58.0890f, 58.0890f, 58.0890f}, {0, 0, 0}, {170.8500f, 170.8500f, 86.7000f}, {114.4695f, 114.4695f, 58.0890f}, {58.0890f, 58.0890f, 29.4780f}, {0, 0, 0}, {170.8500f, 170.8500f, 0}, {114.4695f, 114.4695f, 0},
    {58.0890f, 58.0890f, 0}, {0, 0, 0}, {170.8500f, 86.7000f, 255.0000f}, {114.4695f, 58.0890f, 170.8500f}, {58.0890f, 29.4780f, 86.7000f}, {0, 0, 0}, {170.8500f, 86.7000f, 170.8500f}, {114.4695f, 58.0890f, 114.4695f}, {58.0890f, 29.4780f, 58.0890f},
    {0, 0, 0}, {170.8500f, 86.7000f, 86.7000f}, {114.4695f, 58.0890f, 58.0890f}, {58.0890f, 29.4780f, 29.4780f}, {0, 0, 0}, {170.8500f, 86.7000f, 0}, {114.4695f, 58.0890f, 0}, {58.0890f, 29.4780f, 0}, {0, 0, 0}, {170.8500f, 0, 255.0000f},
    {114.4695f, 0, 170.8500f}, {58.0890f, 0, 86.7000f}, {0, 0, 0}, {170.8500f, 0, 170.8500f}, {114.4695f, 0, 114.4695f}, {58.0890f, 0, 58.0890f}, {0, 0, 0}, {170.8500f, 0, 86.7000f}, {114.4695f, 0, 58.0890f}, {58.0890f, 0, 29.4780f}, {0, 0, 0},
    {170.8500f, 0, 0}, {114.4695f, 0, 0}, {58.0890f, 0, 0}, {0, 0, 0}, {86.7000f, 255.0000f, 255.0000f}, {58.0890f, 170.8500f, 170.8500f}, {29.4780f, 86.7000f, 86.7000f}, {0, 0, 0}, {86.7000f, 255.0000f, 170.8500f}, {58.0890f, 170.8500f, 114.4695f},
    {29.4780f, 86.7000f, 58.0890f}, {0, 0, 0}, {86.7000f, 255.0000f, 86.7000f}, {58.0890f, 170.8500f, 58.0890f}, {29.4780f, 86.7000f, 29.4780f}, {0, 0, 0}, {86.7000f, 255.0000f, 0}, {58.0890f, 170.8500f, 0}, {29.4780f, 86.7000f, 0},
    {0, 0, 0}, {86.7000f, 170.8500f, 255.0000f}, {58.0890f, 114.4695f, 170.8500f}, {29.4780f, 58.0890f, 86.7000f}, {0, 0, 0}, {86.7000f, 170.8500f, 170.8500f}, {58.0890f, 114.4695f, 114.4695f}, {29.4780f, 58.0890f, 58.0890f},
    {0, 0, 0}, {86.7000f, 170.8500f, 86.7000f}, {58.0890f, 114.4695f, 58.0890f}, {29.4780f, 58.0890f, 29.4780f}, {0, 0, 0}, {86.7000f, 170.8500f, 0}, {58.0890f, 114.4695f, 0}, {29.4780f, 58.0890f, 0}, {0, 0, 0},
    {86.7000f, 86.7000f, 255.0000f}, {58.0890f, 58.0890f, 170.8500f}, {29.4780f, 29.4780f, 86.7000f}, {0, 0, 0}, {86.7000f, 86.7000f, 170.8500f}, {58.0890f, 58.0890f, 114.4695f}, {29.4780f, 29.4780f, 58.0890f}, {0, 0, 0},
    {86.7000f, 86.7000f, 86.7000f}, {58.0890f, 58.0890f, 58.0890f}, {29.4780f, 29.4780f, 29.4780f}, {0, 0, 0}, {86.7000f, 86.7000f, 0}, {58.0890f, 58.0890f, 0}, {29.4780f, 29.4780f, 0}, {0, 0, 0}, {86.7000f, 0, 255.0000f},
    {58.0890f, 0, 170.8500f}, {29.4780f, 0, 86.7000f}, {0, 0, 0}, {86.7000f, 0, 170.8500f}, {58.0890f, 0, 114.4695f}, {29.4780f, 0, 58.0890f}, {0, 0, 0}, {86.7000f, 0, 86.7000f}, {58.0890f, 0, 58.0890f},
    {29.4780f, 0, 29.4780f}, {0, 0, 0}, {86.7000f, 0, 0}, {58.0890f, 0, 0}, {29.4780f, 0, 0}, {0, 0, 0}, {0, 255.0000f, 255.0000f}, {0, 170.8500f, 170.8500f}, {0, 86.7000f, 86.7000f}, {0, 0, 0}, {0, 255.0000f, 170.8500f}, {0, 170.8500f, 114.4695f},
    {0, 86.7000f, 58.0890f}, {0, 0, 0 }, {0, 255.0000f, 86.7000f}, {0, 170.8500f, 58.0890f}, {0, 86.7000f, 29.4780f}, {0, 0, 0}, {0, 255.0000f, 0}, {0, 170.8500f, 0}, {0, 86.7000f, 0}, {0, 0, 0}, {0, 170.8500f, 255.0000f}, {0, 114.4695f, 170.8500f},
    {0, 58.0890f, 86.7000f}, {0, 0, 0}, {0, 170.8500f, 170.8500f}, {0, 114.4695f, 114.4695f}, {0, 58.0890f, 58.0890f}, {0, 0, 0}, {0, 170.8500f, 86.7000f}, {0, 114.4695f, 58.0890f}, {0, 58.0890f, 29.4780f}, {0, 0, 0}, {0, 170.8500f, 0},
    {0, 114.4695f, 0}, {0, 58.0890f, 0}, {0, 0, 0}, {0, 86.7000f, 255.0000f}, {0, 58.0890f, 170.8500f}, {0, 29.4780f, 86.7000f}, {0, 0, 0}, {0, 86.7000f, 170.8500f}, {0, 58.0890f, 114.4695f}, {0, 29.4780f, 58.0890f}, {0, 0, 0}, {0, 86.7000f, 86.7000f},
    {0, 58.0890f, 58.0890f}, {0, 29.4780f, 29.4780f}, {0, 0, 0}, {0, 86.7000f, 0}, {0, 58.0890f, 0}, {0, 29.4780f, 0}, {0, 0, 0}, {0, 0, 255.0000f}, {0, 0, 170.8500f}, {0, 0, 86.7000f}, {0, 0, 0}, {0, 0, 170.8500f}, {0, 0, 114.4695f},
    {0, 0, 58.0890f}, {0, 0, 0}, {0, 0, 86.7000f}, {0, 0, 58.0890f}, {0, 0, 29.4780f}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0} };

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Pinceau dans la scène !!!");
        }

        instance = this;


        for (int i = 0; i < paletteRGB.GetLength(0); i++)
        {

            paletteRGB[i, 0] = paletteRGB[i, 0] / 255;
            paletteRGB[i, 1] = paletteRGB[i, 1] / 255;
            paletteRGB[i, 2] = paletteRGB[i, 2] / 255;

        }
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f);

        clePot = 0;
        clePot1 = 1;


        listeIndexOfPixelsHidden = Enumerable.Range(0, CreatePainting.instance.M * CreatePainting.instance.N).ToList();
        indexOfCurrentPixel = SelectPixelRandomlyFromPainting();
        //indexOfCurrentPixel = 0;

        boutonC.interactable = false;
        boutonM.interactable = false;
        boutonJ.interactable = false;
        boutonN.interactable = false;

    }

    private void Start()
    {
        ReinitialisationColorBars();
        currentColorBarImages[0].SetActive(true);
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Pot" && unveil == false) // Si le pinceau touche un pot
        {
            bool perdu = false;
            slotsOccupes += 1;
                
            clePot = other.gameObject.GetComponent<Pot>().potId;
            if (clePot == 17)
            {
                numberPotsMagenta += 1;
                perdu = CheckIfGameOver(numberPotsMagenta);
            }

            if (clePot == 65)
            {
                numberPotsCyan += 1;
                perdu = CheckIfGameOver(numberPotsCyan);
        }

            if (clePot == 5)
            {
                numberPotsJaune += 1;
                perdu = CheckIfGameOver(numberPotsJaune);
            }

            if (clePot == 2)
            {
                numberPotsNoir += 1;
                perdu = CheckIfGameOver(numberPotsNoir);
            }

            
            if (perdu)
            {
                print("Perdu !");
                SceneManager.LoadScene("MenuPrincipal");
            }

            else
            {
                clePot1 = clePot1 + clePot - 1;
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(paletteRGB[clePot1 - 1, 0], paletteRGB[clePot1 - 1, 1], paletteRGB[clePot1 - 1, 2]);
                ReinitialisationColorBars();
                SurligneCurrentColor();
                bool win = CheckIfWin();
                if (win)
                {
                    print("Win !");
                    List<int> listeIndexOfPixels = FindIndexOfEveryPixelWithSameColor(CreatePainting.instance.listePixels[indexOfCurrentPixel]);
                    StartCoroutine(UnveilPixelsOfSameColor(listeIndexOfPixels));
                    CheckIfWin();

                }

                Destroy(other.gameObject);
            }
        }

        else if (other.gameObject.tag == "PotEau" && unveil == false)
        {
            if (numberPotsMagenta == 0 & numberPotsJaune == 0 & numberPotsCyan == 0 & numberPotsNoir == 0)
            {
                print("Rien à effacer");
            }

            else
            {
                GoutteEau(currentColorBar);
                Destroy(other.gameObject);
            }
        }
    }

    public void GoutteEau(int currentColorBar)
    {
        if (currentColorBar == 0)
        {

            if (numberPotsCyan > 0)
            {
                {
                    clePot1 = clePot1 - 64;
                    numberPotsCyan = numberPotsCyan - 1;
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(paletteRGB[clePot1 - 1, 0], paletteRGB[clePot1 - 1, 1], paletteRGB[clePot1 - 1, 2]);
                    ReinitialisationColorBars();
                    ReinitialisationSurlignage();
                    SurligneCurrentColor();
                }
            }

        }

        else if (currentColorBar == 1)
        {

            if (numberPotsMagenta > 0)
            {
                {
                    clePot1 = clePot1 - 16;
                    numberPotsMagenta = numberPotsMagenta - 1;
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(paletteRGB[clePot1 - 1, 0], paletteRGB[clePot1 - 1, 1], paletteRGB[clePot1 - 1, 2]);
                    ReinitialisationColorBars();
                    ReinitialisationSurlignage();
                    SurligneCurrentColor();
                }
            }

        }

        else if (currentColorBar == 2)
        {

            if (numberPotsJaune > 0)
            {
                {
                    clePot1 = clePot1 - 4;
                    numberPotsJaune = numberPotsJaune - 1;
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(paletteRGB[clePot1 - 1, 0], paletteRGB[clePot1 - 1, 1], paletteRGB[clePot1 - 1, 2]);
                    ReinitialisationColorBars();
                    ReinitialisationSurlignage();
                    SurligneCurrentColor();
                }
            }

        }

        else
        {

            if (numberPotsNoir > 0)
            {
                {
                    clePot1 = clePot1 - 1;
                    numberPotsNoir= numberPotsNoir - 1;
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(paletteRGB[clePot1 - 1, 0], paletteRGB[clePot1 - 1, 1], paletteRGB[clePot1 - 1, 2]);
                    ReinitialisationColorBars();
                    ReinitialisationSurlignage();
                    SurligneCurrentColor();
                }
            }

        }
    }

    public void ChangeCurrentColorBarPlus()
    {
        if (currentColorBar > 2)
        {
            currentColorBar = 0;
            currentColorBarImages[3].SetActive(false);
            currentColorBarImages[currentColorBar].SetActive(true);

        }

        else
        {
            currentColorBar += 1;
            currentColorBarImages[currentColorBar - 1].SetActive(false);
            currentColorBarImages[currentColorBar].SetActive(true);
        }
            
        print(currentColorBar);
    }

    public void ChangeCurrentColorBarMinus()
    {
        if (currentColorBar > 0)
        {
            currentColorBar = currentColorBar - 1;
            currentColorBarImages[currentColorBar+1].SetActive(false);
            currentColorBarImages[currentColorBar].SetActive(true);

        }

        else
        {
            currentColorBar = 3;
            currentColorBarImages[0].SetActive(false);
            currentColorBarImages[currentColorBar].SetActive(true);
        }

        print(currentColorBar);
    }


    public void BonusPot()
    {
        if (unveil == false)
        {
            int[] listePotsNecessaires = ConvertIndexIntoNumberOfPots(CreatePainting.instance.listePixels[indexOfCurrentPixel]);
            if (numberPotsCyan < listePotsNecessaires[0])
            {
                numberPotsCyan += 1;
                clePot1 = clePot1 + 64;

            }

            else if (numberPotsMagenta < listePotsNecessaires[1])
            {
                numberPotsMagenta += 1;
                clePot1 = clePot1 + 16;
            }

            else if (numberPotsJaune < listePotsNecessaires[2])
            {
                numberPotsJaune += 1;
                clePot1 = clePot1 + 4;
            }

            else if (numberPotsNoir < listePotsNecessaires[3])
            {
                numberPotsNoir += 1;
                clePot1 = clePot1 + 1;
            }

            else
            {
                // On va enlever un pot
                print("On enlève un pot");
                if (numberPotsCyan > listePotsNecessaires[0])
                {
                    numberPotsCyan -= 1;
                    clePot1 = clePot1 - 64;

                }

                else if (numberPotsMagenta > listePotsNecessaires[1])
                {
                    numberPotsMagenta -= 1;
                    clePot1 = clePot1 - 16;
                }

                else if (numberPotsJaune > listePotsNecessaires[2])
                {
                    numberPotsJaune -= 1;
                    clePot1 = clePot1 - 4;
                }

                else if (numberPotsNoir > listePotsNecessaires[3])
                {
                    numberPotsNoir -= 1;
                    clePot1 = clePot1 - 1;
                }

            }

            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(paletteRGB[clePot1 - 1, 0], paletteRGB[clePot1 - 1, 1], paletteRGB[clePot1 - 1, 2]);
            ReinitialisationColorBars();
            SurligneCurrentColor();
            bool win = CheckIfWin();
            if (win)
            {
                print("Win !");
                List<int> listeIndexOfPixels = FindIndexOfEveryPixelWithSameColor(CreatePainting.instance.listePixels[indexOfCurrentPixel]);
                StartCoroutine(UnveilPixelsOfSameColor(listeIndexOfPixels));

            }
        }
        

    }

    public IEnumerator LauchRecette()
    {
        bool onlyBlack = false;
        int[] listePotsNecessaires = ConvertIndexIntoNumberOfPots(CreatePainting.instance.listePixels[indexOfCurrentPixel]);

        if (listePotsNecessaires[3] == 3)
        {
            onlyBlack = true;
        }
        if (onlyBlack)
        {
            panelRecette1.SetActive(true);
            imagesSplashPanel1[0].color = new Color(0, 0, 0);
            textesSplash1[0].text = "x " + 3;
            yield return new WaitForSeconds(2f);
            panelRecette1.SetActive(false);

        }


        else
        {
            int nombrePotsDifferents = 4;
            int nombrePotsCyan = listePotsNecessaires[0];
            int nombrePotsMagenta = listePotsNecessaires[1];
            int nombrePotsJaune = listePotsNecessaires[2];
            int nombrePotsNoir = listePotsNecessaires[3];

            Image[] imagesSplashPanel;
            TextMeshProUGUI[] texteSplash;

            int lastIndice = 0;
            GameObject panelRecette;

            for (int i = 0; i < 4; i++)
            {
                if (listePotsNecessaires[i] == 0)
                {
                    nombrePotsDifferents -= 1;
                }
            }

            if (nombrePotsDifferents == 1)
            {
                panelRecette = panelRecette1;
                panelRecette1.SetActive(true);
                imagesSplashPanel = imagesSplashPanel1;
                texteSplash = textesSplash1;
            }

            else if (nombrePotsDifferents == 2)
            {
                panelRecette = panelRecette2;
                panelRecette2.SetActive(true);
                imagesSplashPanel = imagesSplashPanel2;
                texteSplash = textesSplash2;
            }

            else if (nombrePotsDifferents == 3)
            {
                panelRecette = panelRecette3;
                panelRecette3.SetActive(true);
                imagesSplashPanel = imagesSplashPanel3;
                texteSplash = textesSplash3;
            }

            else
            {
                panelRecette = panelRecette4;
                panelRecette4.SetActive(true);
                imagesSplashPanel = imagesSplashPanel4;
                texteSplash = textesSplash4;
            }



            if (nombrePotsCyan > 0)
            {
                imagesSplashPanel[lastIndice].color = new Color(0, 255, 255);
                texteSplash[lastIndice].text = "x " + nombrePotsCyan;
                lastIndice += 1;
            }


            if (nombrePotsMagenta > 0)
            {
                imagesSplashPanel[lastIndice].color = new Color(255, 0, 255);
                texteSplash[lastIndice].text = "x " + nombrePotsMagenta;
                lastIndice += 1;
            }

            if (nombrePotsJaune > 0)
            {
                imagesSplashPanel[lastIndice].color = new Color(255, 255, 0);
                texteSplash[lastIndice].text = "x " + nombrePotsJaune;
                lastIndice += 1;
            }

            if (nombrePotsNoir > 0)
            {
                imagesSplashPanel[lastIndice].color = new Color(0, 0, 0);
                texteSplash[lastIndice].text = "x " + nombrePotsNoir;
                lastIndice += 1;
            }


            yield return new WaitForSeconds(2f);
            panelRecette.SetActive(false);

        }


    }


    public void BonusRecette()
    {
        StartCoroutine(LauchRecette());

    }

    public int[] ConvertIndexIntoNumberOfPots(int indice)
    {
        string binary = ToBin(indice, 8);
        int numberM = 0;
        int numberC = 0;
        int numberJ = 0;
        int numberN = 0;

        

        if (binary.Substring(0,2) == "00")
        {
            numberC = 0;
        }

        else if (binary.Substring(0, 2) == "01")
        {
            numberC = 1;
        }

        else if (binary.Substring(0, 2) == "10")
        {
            numberC = 2;
        }

        else if (binary.Substring(0, 2) == "11")
        {
            numberC = 3;
        }



        if (binary.Substring(2, 2) == "00")
        {
            numberM = 0;
        }

        else if (binary.Substring(2, 2) == "01")
        {
            numberM = 1;
        }

        else if (binary.Substring(2, 2) == "10")
        {
            numberM = 2;
        }

        else if (binary.Substring(2, 2) == "11")
        {
            numberM = 3;
        }


        if (binary.Substring(4, 2) == "00")
        {
            numberJ = 0;
        }

        else if (binary.Substring(4, 2) == "01")
        {
            numberJ = 1;
        }

        else if (binary.Substring(4, 2) == "10")
        {
            numberJ = 2;
        }

        else if (binary.Substring(4, 2) == "11")
        {
            numberJ = 3;
        }


        if (binary.Substring(6, 2) == "00")
        {
            numberN = 0;
        }

        else if (binary.Substring(6, 2) == "01")
        {
            numberN = 1;
        }

        else if (binary.Substring(6, 2) == "10")
        {
            numberN = 2;
        }

        else if (binary.Substring(6, 2) == "11")
        {
            numberN = 3;
        }


        return new int[]{numberC,numberM,numberJ,numberN};

    }

    public static string ToBin(int value, int len)
    {
        return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
    }



    public bool CheckIfWin()
    {
        if (gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color == targetColor)
            return true;
        return false;
    }

    public bool CheckIfGameOver(int numberPots)
    {
        if (numberPots > 3)
        {
            return true;
        }
        return false;
    }

    public IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reinitialisation()
    {
        slotsOccupes = 0;
        clePot = 0;
        clePot1 = 1;
        numberPotsMagenta = 0;
        numberPotsCyan = 0;
        numberPotsJaune = 0;
        numberPotsNoir = 0;
        ReinitialisationSurlignage();
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f); // Le pinceau redevient blanc

    }

    public void ChangeTargetColor()
    {
        if (listeIndexOfPixelsHidden.Count == 0)
        {
            StartCoroutine(ReloadLevel());

        }

        

        else
         {
            indexOfCurrentPixel = SelectPixelRandomlyFromPainting();
            int indice = CreatePainting.instance.listePixels[indexOfCurrentPixel];
            targetColor = new Color(paletteRGB[indice, 0],paletteRGB[indice, 1],paletteRGB[indice, 2]);
            GameObject ImagePixel = CreatePainting.instance.listeImagesPixel[indexOfCurrentPixel];
            ImagePixel.GetComponent<Image>().color = targetColor;
            //iTween.PunchScale(ImagePixel, new Vector3(1.2f, 1.2f, 1.2f), 1.0f);
         }

    }


    public int[] CalculateIndexForSlider(int currentIndex, int numberPots, int indexPot)
    {
        int[] IdAtteignables = new int[4];

        if (numberPots == 0)
        {
            IdAtteignables = new int[] { currentIndex, currentIndex + indexPot, currentIndex + 2* indexPot, currentIndex + 3*indexPot };
        }

        else if (numberPots == 1)
        {
            IdAtteignables = new int[] { currentIndex-indexPot, currentIndex, currentIndex + indexPot, currentIndex + 2 * indexPot };
        }

        else if (numberPots == 2)
        {
            IdAtteignables = new int[] { currentIndex - 2*indexPot, currentIndex-indexPot, currentIndex, currentIndex + indexPot };
        }

        else if (numberPots == 3)
        {
            IdAtteignables = new int[] { currentIndex - 3* indexPot, currentIndex - 2* indexPot, currentIndex - indexPot, currentIndex };
        }


        return IdAtteignables;
    }

    public void ReinitialisationColorBars()
    {

        idAtteignablesMagenta = CalculateIndexForSlider(clePot1 - 1, numberPotsMagenta,16);
        colorBarMagenta.SetSliderGradient(idAtteignablesMagenta);

        idAtteignablesCyan = CalculateIndexForSlider(clePot1 - 1, numberPotsCyan,64);
        colorBarCyan.SetSliderGradient(idAtteignablesCyan);

        idAtteignablesJaune = CalculateIndexForSlider(clePot1 - 1, numberPotsJaune,4);
        colorBarJaune.SetSliderGradient(idAtteignablesJaune);

        idAtteignablesNoir = CalculateIndexForSlider(clePot1 - 1, numberPotsNoir,1);
        colorBarNoir.SetSliderGradient(idAtteignablesNoir);

        SurligneCurrentColor();


    }

    public void SurligneCurrentColor()
    {

        for (int i=0;i<4;i++)
        {
            if (i == numberPotsCyan)
                currentColorC[i].SetActive(true);
            else
                currentColorC[i].SetActive(false);

            if (i == numberPotsMagenta)
                currentColorM[i].SetActive(true);
            else
                currentColorM[i].SetActive(false);

            if (i == numberPotsJaune)
                currentColorJ[i].SetActive(true);
            else
                currentColorJ[i].SetActive(false);

            if (i == numberPotsNoir)
                currentColorN[i].SetActive(true);
            else
                currentColorN[i].SetActive(false);
        }

    }

    public void ReinitialisationSurlignage()
    {
        for (int i=0;i<3;i++)
        {
            currentColorC[i].SetActive(false);
            currentColorM[i].SetActive(false);
            currentColorJ[i].SetActive(false);
            currentColorN[i].SetActive(false);
        }
    }


    public int SelectPixelRandomlyFromPainting()
    {
        int indicePixel;

        indicePixel = listeIndexOfPixelsHidden[UnityEngine.Random.Range(0, listeIndexOfPixelsHidden.Count)];
        listeIndexOfPixelsHidden.Remove(indicePixel);
        return indicePixel;
    }



    public List<int> FindIndexOfEveryPixelWithSameColor(int indiceCouleur)
    {
        List<int> listeIndexOfPixelsWithSameColor = new List<int> {};
        for (int i=0;i<listeIndexOfPixelsHidden.Count;i++)
        {
            int indice = CreatePainting.instance.listePixels[listeIndexOfPixelsHidden[i]];
            if (indice == indiceCouleur)
            {
                listeIndexOfPixelsWithSameColor.Add(listeIndexOfPixelsHidden[i]);
            }
        }

        return listeIndexOfPixelsWithSameColor;

    }

    public IEnumerator UnveilPixelsOfSameColor(List<int> listeIndex)
    {
        unveil = true;
        int ind = clePot1;
        for (int i=0;i<listeIndex.Count;i++)
        {
            int indice = listeIndex[i];
            Color col = new Color(paletteRGB[ind-1, 0], paletteRGB[ind-1, 1], paletteRGB[ind-1, 2]);
            GameObject ImagePixel = CreatePainting.instance.listeImagesPixel[indice];
            ImagePixel.GetComponent<Image>().color = col;
            yield return new WaitForSeconds(0.15f);
            listeIndexOfPixelsHidden.Remove(indice);
        }
        yield return new WaitForSeconds(0.5f);
        ChangeTargetColor();
        Reinitialisation();
        ReinitialisationColorBars();
        yield return new WaitForSeconds(0.2f);
        unveil = false;
    }

}
