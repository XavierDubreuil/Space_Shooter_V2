using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// La classe PageInitiale permet de g�rer la page initiale du jeu.
/// </summary>
public class PageInitiale : MonoBehaviour
{
    

    [SerializeField] Canvas canvasParametre;
    [SerializeField] Sprite imageSonActiv�;
    [SerializeField] Sprite imageSonD�sactiv�;
    [SerializeField] GameObject btnParamSon;
    [SerializeField] AudioSource SonD�but;

    private void Start()
    {
        if (canvasParametre != null)
        {
            canvasParametre.gameObject.SetActive(false);
        }
        Image image = btnParamSon.GetComponent<Image>();

        if (PlayerPrefs.HasKey("sonActiv�"))
        {
            int sonActiv� = PlayerPrefs.GetInt("sonActiv�");

            switch (sonActiv�)
            {
                case 0:
                    image.sprite = imageSonD�sactiv�;
                    break;
                case 1:
                    image.sprite = imageSonActiv�;
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("sonActiv�", 1);
            PlayerPrefs.Save();
            image.sprite = imageSonActiv�;
        }
    }

    //Voici la r�f�rence o� nous avons trouv� l'information ci-dessous, pour le changement de sc�ne: https://www.youtube.com/watch?v=EMo-MaKkP9s
    public void ChangerDeScene()
    {
        SceneManager.LoadScene("Marc");
    }
    /// <summary>
    /// La m�thode Parametre() permet d'afficher un pop-up pour changer les param�tres du jeu.
    /// </summary>
    public void Parametre()
    {
        if (canvasParametre != null)
        {
            canvasParametre.gameObject.SetActive(!canvasParametre.gameObject.active);
        }
    }
    /// <summary>
    /// S'occupe de changer le fait d'entendre le son ou non
    /// </summary>
    public void ChangerParamSon()
    {
        if (btnParamSon != null)
        {
            Image image = btnParamSon.GetComponent<Image>();

            if (image != null)
            {

                if (PlayerPrefs.HasKey("sonActiv�"))
                {
                    int sonActiv� = PlayerPrefs.GetInt("sonActiv�");

                    switch (sonActiv�)
                    {
                        case 0:
                            image.sprite = imageSonActiv�;
                            SonD�but.Play();
                            PlayerPrefs.SetInt("sonActiv�", 1);
                            PlayerPrefs.Save();
                            break;
                        case 1:
                            image.sprite = imageSonD�sactiv�;
                            SonD�but.Stop();
                            PlayerPrefs.SetInt("sonActiv�", 0);
                            PlayerPrefs.Save();
                            break;
                    }
                }
                else
                {
                    image.sprite = imageSonActiv�;
                    PlayerPrefs.SetInt("sonActiv�", 1);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
