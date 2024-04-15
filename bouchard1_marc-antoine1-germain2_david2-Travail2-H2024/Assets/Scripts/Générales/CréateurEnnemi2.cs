using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe CréateurEnnemi2 permet de gérer l'apparition des objets Ennemi2.
/// </summary>
public class CréateurEnnemi2 : MonoBehaviour
{
    [SerializeField] GameObject Ennemi2; //Ennemi2 est le prefab qui doit être utiliser pour l'apparition des Ennemi2.
    [SerializeField] GameObject LimiteCoinGauche; //Limite coin gauche pour l'apparition des Ennemi2.
    [SerializeField] GameObject LimiteCoinDroit; //Limite coin droit pour l'apparition des Ennemi2.


    const float MIN_VITESSE_APPARITION_GROUPE = 1f;
    const float VITESSE_APPARITION_ENTRE_ENNEMISGROUPE = 0.5f;
    float vitesseApparitionGroupe = 6f; //La vitesse à laquelle les groupes d'Ennemi2 vont apparaitres.

    float tempsÉcoulésGroupe = 0f;
    float tempsÉcoulésEntreEnnemisGroupe = 0f;

    float xPositionInitialeEnnemi = 0f; //Le x de la position initiale de l'Ennemi2.
    float yPositionInitialeEnnemi = 0f; //Le y de la position initiale de l'Ennemi2.

    float compteurNbEnnemisApparus = 0f; //Compte le nombre d'ennemis apparus pour un groupe d'Ennemi2.

    int balise_min_ennemi_groupe = 0;
    int balise_max_ennemi_groupe = 0;
    int nb_ennemi_groupe = 0;

    int nb_groupe = 0;
    int compteur_groupe = 0;

    float vitesseEnnemis = 0;
    float delaiBalle = 0;

    public bool apparition_finie { get; private set; } = false;

    void Start()
    {
        //Permet d'initialiser la position initiale (y) des Ennemi2:
        if (LimiteCoinGauche != null && LimiteCoinDroit != null)
            yPositionInitialeEnnemi = LimiteCoinGauche.transform.position.y;
    }

    void Update()
    {
        //Permet de gérer l'apparition des Ennemi2:
        if (compteur_groupe < nb_groupe && LimiteCoinGauche != null && LimiteCoinDroit != null && (tempsÉcoulésGroupe >= vitesseApparitionGroupe && compteurNbEnnemisApparus == 0) || (tempsÉcoulésEntreEnnemisGroupe >= VITESSE_APPARITION_ENTRE_ENNEMISGROUPE))
        {
            GameObject ObjetEnnemi2 = ObjectPool.Instance.GetPooledObject(Ennemi2);
            if (ObjetEnnemi2 != null)
            {
                if (compteurNbEnnemisApparus == 0)
                {
                    nb_ennemi_groupe = Random.Range(balise_min_ennemi_groupe, balise_max_ennemi_groupe + 1);
                    xPositionInitialeEnnemi = UnityEngine.Random.Range(LimiteCoinGauche.transform.position.x, LimiteCoinDroit.transform.position.x);
                }

                ObjetEnnemi2.transform.position = new Vector2(xPositionInitialeEnnemi, yPositionInitialeEnnemi);
                ObjetEnnemi2.transform.rotation = transform.rotation;
                ObjetEnnemi2.GetComponent<Ennemi2>().setVitesse(vitesseEnnemis, delaiBalle);
                ObjetEnnemi2.SetActive(true);

                compteurNbEnnemisApparus++;
                //Set la vitesse pour qu'elle puisse changer selon les vagues

                tempsÉcoulésEntreEnnemisGroupe = 0f;

                if (compteurNbEnnemisApparus == nb_ennemi_groupe)
                {
                    tempsÉcoulésGroupe = 0f;
                    compteurNbEnnemisApparus = 0;
                    compteur_groupe++;
                }
            }
        }
        else if (compteur_groupe >= nb_groupe)
        {
            apparition_finie = true;
        }
        //Permet de gérer le temps écoulé entre les groupes d'Ennemi2 et les Ennemi2 d'un groupe:
        if (compteurNbEnnemisApparus == 0)
            tempsÉcoulésGroupe += Time.deltaTime;
        else
            tempsÉcoulésEntreEnnemisGroupe += Time.deltaTime;

    }

    /// <summary>
    /// Pour changer la vitesse d'apparition des groupes d'ennemis, par exemple, lors d'un changement de niveaux.
    /// </summary>
    public void ChangerVitesseApparitionEnnemis()
    {
        float tempsSupprimé = 0.5f;
        if (vitesseApparitionGroupe - tempsSupprimé >= MIN_VITESSE_APPARITION_GROUPE)
            vitesseApparitionGroupe = vitesseApparitionGroupe - tempsSupprimé;
    }
    /// <summary>
    /// Change les paramètre du créateur pour s'adapter à la vague en cours
    /// </summary>
    /// <param name="nb_groupe"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="vitesseApparition"></param>
    /// <param name="vitesse"></param>
    /// <param name="delai_balle"></param>
    public void newWave(int nb_groupe, int min, int max, float vitesseApparition, float vitesse, float delai_balle)
    {
        apparition_finie = false;
        compteur_groupe = 0;
        this.nb_groupe = nb_groupe;
        balise_min_ennemi_groupe = min;
        balise_max_ennemi_groupe = max;
        vitesseApparitionGroupe = vitesseApparition;
        vitesseEnnemis = vitesse;
        delaiBalle = delai_balle;
    }
}
