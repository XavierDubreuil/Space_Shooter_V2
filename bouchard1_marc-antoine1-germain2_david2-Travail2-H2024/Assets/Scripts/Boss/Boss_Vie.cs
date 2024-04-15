using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_Vie : MonoBehaviour
{
    [SerializeField] float nbDeViesInitiales = 10f; //Le nombre de vie initiale du Boss.
    [SerializeField] Score score; //Le script qui g�re le score du Player.
    [SerializeField] AudioSource boss_dead;
    public float nbViesCourantes { get; private set; }

    bool estMort = false; //Permet de dire si le Boss est mort

    void Start()
    {
        boss_dead.Stop(); //Permet de s'assurer que le son est arr�t�.
        nbViesCourantes = nbDeViesInitiales; //Permet d'initialis� le nombre de vie du Boss.
    }

    /// <summary>
    /// Permet de diminuer la vie du Boss si le Boss n'est pas encore mort.
    /// </summary>
    public void DiminuerVie()
    {
        if (nbViesCourantes > 0 && !estMort)
        {
            nbViesCourantes--;
            V�rifierVivant();
        }        
    }

    /// <summary>
    /// La m�thode EstVivant() permet de savoir si le Boss est vivant ou mort.
    /// </summary>
    /// <returns>true: si le Boss est vivant, false: si le Boss est mort</returns>
    public bool EstVivant()
    {
        if (nbViesCourantes == 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// La m�thode V�rifierVivant() permet de savoir si le Boss est vivant, mais surtout, il permet de faire mourir le Boss si le nombre de vie est �gale
    /// � 0.
    /// </summary>
    /// <returns></returns>
    private bool V�rifierVivant()
    {
        if (nbViesCourantes == 0)
        {
            gameObject.SetActive(false);

            if (Player_g�rerSon.Instance.SonEstActiv�())
                boss_dead.Play();
            if (score != null)
                score.AugmenterScoreBoss();

            estMort = true;
            return false;
        }
        return true;
    }

    /// <summary> 
    /// La m�thode R�initialiserVie() permet de r�initialiser les valeurs du script.
    /// </summary>
    public void R�initialiserVie()
    {
        nbViesCourantes = nbDeViesInitiales;
        estMort = false;
    }
}
