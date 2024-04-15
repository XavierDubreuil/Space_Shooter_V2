using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe CréateurEnnemi1 permet de gérer l'apparition des objets Ennemi1.
/// </summary>
public class CréateurEnnemi1 : MonoBehaviour
{
    [SerializeField] GameObject[] GroupesDEnnemis; //Comprend tous les groupes d'Ennemi1 (un groupe d'ennemi comprend plusieurs Ennemi1)
    [SerializeField] GameObject LimiteCoinGauche; //Limite coin gauche pour l'apparition des Ennemi1
    [SerializeField] GameObject LimiteCoinDroit;  //Limite coin droit pour l'apparition des Ennemi1

    Direction[] directions = new Direction[3] { Direction.Droite, Direction.Gauche, Direction.Bas }; //Les directions disponiblent pour les groupes d'Ennemi1

    float tempsÉcoulé = 0f; //Temps écoulé depuis la dernière apparition d'un objet Ennemi1.
    float tempsÉcouléMax = 0f; //Le temps que doit atteindre la variable tempsÉcoulé pour faire apparaitre un objet Ennemi1.

    float MinTempsApparition = 1f; //Le temps d'apparition minimale à atteindre.
    float MaxTempsApparition = 3f; //Le temps d'apparition maximale à atteindre.

    int nb_groupe = 0;
    int compteur_groupe = 0;

    float vitesseEnnemi;

    public bool apparition_finie { get; private set; } = false;
    void Start()
    {
        tempsÉcouléMax = ObtenirTempsHasardApparition();
    }

    void Update()
    {
        //Permet de gérer l'apparition des Ennemi1:
        if (compteur_groupe < nb_groupe && LimiteCoinGauche != null && LimiteCoinDroit != null && tempsÉcoulé >= tempsÉcouléMax)
        {
            GameObject GroupeDEnnemiChoisi = ObtenirGroupeEnnemi1Hasard();
            GameObject ObjetEnnemi1 = ObjectPool.Instance.GetPooledObject(GroupeDEnnemiChoisi);
            if (ObjetEnnemi1 != null)
            {
                float xPositionEnnemi = UnityEngine.Random.Range(LimiteCoinGauche.transform.position.x, LimiteCoinDroit.transform.position.x);
                ObjetEnnemi1.transform.position = new Vector2(xPositionEnnemi, LimiteCoinGauche.transform.position.y);
                ObjetEnnemi1.transform.rotation = LimiteCoinGauche.transform.rotation;
                ObjetEnnemi1.GetComponent<Ennemi1>().setVitesse(vitesseEnnemi);
                ObjetEnnemi1.SetActive(true);

                Direction directionHasard = ObtenirDirectionHasard();

                for (int i = 0; i < ObjetEnnemi1.transform.childCount; i++)
                {
                    //La fonction GetChild() permet d'obtenir un GameObject enfant de l'objet courant à un index en particulier.
                    //Trouver sur le site: https://forum.unity.com/threads/how-to-activate-a-child-of-a-parent-object.378133/
                    ObjetEnnemi1.transform.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }

                Ennemi1[] ennemis1 = ObjetEnnemi1.GetComponentsInChildren<Ennemi1>();
                foreach (Ennemi1 ennemi in ennemis1)
                {
                    ennemi.InitialiserLaDirection(directionHasard);
                    ennemi.InitialiserLaRotation();
                }
            }
            tempsÉcoulé = 0f;
            compteur_groupe++;
            tempsÉcouléMax = ObtenirTempsHasardApparition();
        }
        else if (compteur_groupe >= nb_groupe)
        {
            apparition_finie = true;
        }
        tempsÉcoulé += Time.deltaTime;
    }

    /// <summary>
    /// La méthode ObtenirTempsHasardApparition() permet d'obtenir un temps à atteindre au hasard avant l'apparition d'un objet Ennemi1_Groupe.
    /// </summary>
    /// <returns></returns>
    private float ObtenirTempsHasardApparition()
    {
        float tempsApparition = UnityEngine.Random.Range(MinTempsApparition, MaxTempsApparition);
        return tempsApparition;
    }

    /// <summary>
    /// La méthode ObtenirDirectionHasard() permet d'obtenir une direction au hasard (gauche, droite, bas)
    /// </summary>
    /// <returns></returns>
    private Direction ObtenirDirectionHasard()
    {
        int indexDirectionHasard = UnityEngine.Random.Range(0, 3);
        return directions[indexDirectionHasard];
    }

    /// <summary>
    /// La méthode ObtenirGroupeEnnemi1Hasard() permet d'obtenir un groupe d'ennemi1 au hasard.
    /// </summary>
    /// <returns></returns>
    private GameObject ObtenirGroupeEnnemi1Hasard()
    {
        int nombreHasard = UnityEngine.Random.Range(0, GroupesDEnnemis.Length - 1);
        return GroupesDEnnemis[nombreHasard];
    }

    /// <summary>
    /// La méthode ChangerVitesseApparitionEnnemis() permet de changer la vitesse d'apparition des Ennemi1, par exemple, lors d'un changement de niveaux.
    /// </summary>
    public void ChangerVitesseApparitionEnnemis(float delai_supprimmé)
    {
        if (MaxTempsApparition - delai_supprimmé >= MinTempsApparition)
            MaxTempsApparition = MaxTempsApparition - delai_supprimmé;
    }
    /// <summary>
    /// Permet d'adapter certain paramètre des ennemis 1 selon la vague
    /// </summary>
    /// <param name="nb_groupe"></param>
    /// <param name="vitesseSupprimmé"></param>
    /// <param name="vitesse"></param>
    public void newWave(int nb_groupe, float vitesseSupprimmé, float vitesse)
    {
        apparition_finie = false;
        compteur_groupe = 0;
        this.nb_groupe = nb_groupe;
        vitesseEnnemi = vitesse;
        ChangerVitesseApparitionEnnemis(vitesseSupprimmé);
    }
}
