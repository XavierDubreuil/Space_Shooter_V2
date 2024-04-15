using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Boss_ApparitionCoeur permet de g�rer l'apparition du coeur (la partie qui fait baisser la vie du Boss lorsqu'elle se fait toucher)
/// </summary>
public class Boss_ApparitionCoeur : MonoBehaviour
{
    [SerializeField] GameObject Coeur; //C'est le GameObject qui repr�sente le coeur du Boss
    [SerializeField] float tempsApparitionCoeur = 3f; //Le temps d'apparitiond du coeur.
    [SerializeField] int nbCibles = 2; //Le nombre de cibles du Boss.

    [SerializeField] GameObject Cible1; //Cible 1 du Boss (droite)
    [SerializeField] GameObject Cible2; //Cible 2 du Boss (gauche)

    Boss_Cible Boss_Cible_Cible1; //Le script qui g�re la cible 1 du Boss
    Boss_Cible Boss_Cible_Cible2; //Le script qui g�re la cible 2 du Boss

    int nbCiblesAtteintes = 0;
    bool coeurEstVisible = false;
    float tempsEcoules = 0f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Coeur.SetActive(false);
        if (Cible1 != null)
            Boss_Cible_Cible1 = Cible1.GetComponent<Boss_Cible>();
        if (Cible2 != null)
            Boss_Cible_Cible2 = Cible2.GetComponent<Boss_Cible>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si le coeur est visible, g�rer le temps d'apparition du coeur:
        if (coeurEstVisible)
        {
            if (tempsEcoules >= tempsApparitionCoeur)
            {

                FaireDisparaitreCoeur();
                tempsEcoules = 0f;
                if (Boss_Cible_Cible1 != null)
                {
                    Boss_Cible_Cible1.ActiverCible();
                }
                if (Boss_Cible_Cible2 != null)
                {
                    Boss_Cible_Cible2.ActiverCible();
                }
            }
            tempsEcoules += Time.deltaTime;
        }
    }

    /// <summary>
    /// La m�thode FaireApparaitreCoeur() permet de faire apparaitre le coeur du Boss.
    /// </summary>
    private void FaireApparaitreCoeur()
    {
        if (Coeur != null)
        {
            Coeur.gameObject.SetActive(true);
            coeurEstVisible = true;
        }
    }

    /// <summary>
    /// La m�thode FaireDisparaitreCoeur() permet de faire disparaitre le coeur du Boss.
    /// </summary>
    private void FaireDisparaitreCoeur()
    {
        Coeur.gameObject.SetActive(false);
        coeurEstVisible = false;
    }

    /// <summary>
    /// La m�thode AugmenterNbCiblesAtteintes() permet de g�rer l'apparition du coeur (lorsque le nombre de cible atteinte est �gale au nombre de cibles existantes
    /// on affiche le coeur du Boss).
    /// </summary>
    public void AugmenterNbCiblesAtteintes()
    {
        nbCiblesAtteintes++;
        if (nbCiblesAtteintes == nbCibles)
        {
            FaireApparaitreCoeur();
            nbCiblesAtteintes = 0;
        }
    }

    /// <summary>
    /// La m�thode R�initialiserValeur() permet de r�initialiser les valeurs de ce script.
    /// </summary>
    public void R�initialiserValeur()
    {
        nbCiblesAtteintes = 0;
        coeurEstVisible = false;
        tempsEcoules = 0f;
        FaireDisparaitreCoeur();
    }
}
