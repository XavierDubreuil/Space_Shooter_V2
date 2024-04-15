using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// La classe PageInitiale permet de gérer la page initiale du jeu.
/// </summary>
public class PageInitiale : MonoBehaviour
{
    

    [SerializeField] Canvas canvasParametre;
    [SerializeField] Sprite imageSonActivé;
    [SerializeField] Sprite imageSonDésactivé;
    [SerializeField] GameObject btnParamSon;
    [SerializeField] AudioSource SonDébut;

    private void Start()
    {
        if (canvasParametre != null)
        {
            canvasParametre.gameObject.SetActive(false);
        }
        Image image = btnParamSon.GetComponent<Image>();

        if (PlayerPrefs.HasKey("sonActivé"))
        {
            int sonActivé = PlayerPrefs.GetInt("sonActivé");

            switch (sonActivé)
            {
                case 0:
                    image.sprite = imageSonDésactivé;
                    break;
                case 1:
                    image.sprite = imageSonActivé;
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("sonActivé", 1);
            PlayerPrefs.Save();
            image.sprite = imageSonActivé;
        }
    }

    //Voici la référence où nous avons trouvé l'information ci-dessous, pour le changement de scène: https://www.youtube.com/watch?v=EMo-MaKkP9s
    public void ChangerDeScene()
    {
        SceneManager.LoadScene("Marc");
    }
    /// <summary>
    /// La méthode Parametre() permet d'afficher un pop-up pour changer les paramètres du jeu.
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

                if (PlayerPrefs.HasKey("sonActivé"))
                {
                    int sonActivé = PlayerPrefs.GetInt("sonActivé");

                    switch (sonActivé)
                    {
                        case 0:
                            image.sprite = imageSonActivé;
                            SonDébut.Play();
                            PlayerPrefs.SetInt("sonActivé", 1);
                            PlayerPrefs.Save();
                            break;
                        case 1:
                            image.sprite = imageSonDésactivé;
                            SonDébut.Stop();
                            PlayerPrefs.SetInt("sonActivé", 0);
                            PlayerPrefs.Save();
                            break;
                    }
                }
                else
                {
                    image.sprite = imageSonActivé;
                    PlayerPrefs.SetInt("sonActivé", 1);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
