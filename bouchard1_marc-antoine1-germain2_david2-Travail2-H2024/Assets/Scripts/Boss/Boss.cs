using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// La classe Boss permet de gérer les éléments générales du Boss. En effet, il permet de préparer le Boss, de choisir une attaque au hasard,
/// de réinitialiser le Boss et permet de désactiver le Boss au grand complet. 
/// </summary>
public class Boss : MonoBehaviour
{
    [SerializeField] GameObject PositionInitiale; //Corrspond à la position initiale à la quelle le Boss va apparaitre
    [SerializeField] GameObject PositionFinale; //Correspond à la position finale du Boss

    [SerializeField] Boss_Attaque1_laser Script_Attaque1; //Script pour l'attaque 1
    [SerializeField] bullet_hell ScriptBullet_hell; //Script pour l'attaque 2
    [SerializeField] Boss_Attaque_3 Script_Attaque3; //Script pour l'attaque 3

    [SerializeField] Boss_Vie boss_Vie;
    [SerializeField] Boss_ApparitionCoeur boss_ApparitionCoeur;

    [SerializeField] AudioSource boss_spawn; //Le son que le Boss fait lorsque le Boss apparait.
    
    [SerializeField] Canvas lifeBar; //Est un canvas utilisé spécialement pour la barre de vie du Boss
    [SerializeField] Slider slider_Health; //La barre de vie du Boss


    float vitesseBossPréparation = 1f; //La vitesse de déplacement du Boss lors de la préparation avant l'attaque.

    bool estArrivéPositionFinale = false; //Permet de savoir si le Boss est arrivé à la position finale (s'il a fini sa préparation)


    bool aChoisitAttaque = false; //Permet de savoir si le Boss a déjà fini son attaque.


    Boss_Cible[] Boss_Cibles; //Comprend toutes les cibles du Boss.

    void Start()
    {
        slider_Health.maxValue = boss_Vie.nbViesCourantes; //Initialiser la valeur maximale de la barre de vie
        slider_Health.value = 3f; //Mettre une valeur par défaut à la barre de vie.
        boss_spawn.Stop(); //S'assurer que le son d'apparition est arrété.

        transform.position = PositionInitiale.transform.position; //On donne une position par défaut au Boss

        Boss_Cibles = GetComponentsInChildren<Boss_Cible>();

        foreach (Boss_Cible Boss_Cible in Boss_Cibles)
        {
            Boss_Cible.DésactiverCible();
        }
    }

    //Permet de gérer l'apparition du Boss ainsi que son attaque (il n'a que 1 attaque par apparition):
    void Update()
    {
        if (boss_Vie.EstVivant())
        {
            slider_Health.value = boss_Vie.nbViesCourantes; //Permet de mettre à jour la barre de vie du Boss.
            if (estArrivéPositionFinale)
            {
                //Lorsque le Boss est arrivé à la position finale (suite à la préparation) et qu'il n'a pas encore choisit son attaque:
                if (!aChoisitAttaque)
                {
                    int typeAttaque = (int)ObtenirTypeAttaqueHasard();

                    switch (typeAttaque)
                    {
                        case 1:
                            Attaque1();
                            aChoisitAttaque = true;
                            break;
                        case 2:
                            Attaque2();
                            aChoisitAttaque = true;
                            break;
                        case 3:
                            Attaque3();
                            break;
                    }
                }
            }
            else
            {
                //Lorsque le Boss va à la position finale (lors de la préparation):

            
                if (Player_gérerSon.Instance.SonEstActivé())
                    boss_spawn.Play();
                lifeBar.enabled = true;

                //Préparation vers la position finale:
                Préparation();
                VérifierPosition();
            }
        }
    }
    /// <summary>
    /// La méthode Préparation() permet de diriger le Boss vers la position finale.
    /// </summary>
    private void Préparation()
    {
        transform.Translate(new Vector2(0, -1).normalized * vitesseBossPréparation * Time.deltaTime, Space.Self);
    }

    /// <summary>
    /// La méthode VérifierPosition() permet de vérifier si le Boss est arrivé à la position finale. Si il est arrivé, la méthode active alors les cibles.
    /// </summary>
    private void VérifierPosition()
    {
        if (transform.position.y <= PositionFinale.transform.position.y)
        {
            estArrivéPositionFinale = true;
            foreach (Boss_Cible Boss_Cible in Boss_Cibles)
            {
                Boss_Cible.ActiverCible();
            }
        }
    }

    /// <summary>
    /// La méthode Attaque1() permet de gérer l'exécution du script qui concerne l'attaque 1 du Boss.
    /// </summary>
    private void Attaque1()
    {
        if (!Script_Attaque1.enabled)
            Script_Attaque1.enabled = true;
    }

    /// <summary>
    /// La méthode Attaque2() permet de gérer l'exécution du script qui concerne l'attaque 2 du Boss.
    /// </summary>
    private void Attaque2()
    {
        if (!ScriptBullet_hell.enabled)
            ScriptBullet_hell.enabled = true;
    }
    /// <summary>
    ///  La méthode Attaque3() permet de gérer l'exécution du script qui concerne l'attaque 3 du Boss.
    /// </summary>
    private void Attaque3()
    {
        if (!Script_Attaque3.enabled)
            Script_Attaque3.enabled = true;
    }

    /// <summary>
    /// La méthode ObtenirTypeAttaqueHasard() permet d'obtenir une attaque au hasard.
    /// </summary>
    /// <returns></returns>
    private int ObtenirTypeAttaqueHasard()
    {
        return Random.Range(1,4); //1,2 ou 3
    }

    public bool EstVivant()
    {
        return boss_Vie.EstVivant();
    }

    /// <summary>
    /// La méthode RéinitialiserValeur() permet de réinitialiser les valeurs du boss afin de reprendre du début comme si s'était un nouveau Boss.
    /// </summary>
    public void RéinitialiserValeur()
    {
        transform.position = PositionInitiale.transform.position;
        transform.rotation = Quaternion.EulerRotation(0, 0, 0);


        Script_Attaque1.enabled = false;
        ScriptBullet_hell.enabled = false;

        estArrivéPositionFinale = false;
        aChoisitAttaque = false;

        Boss_Cibles = GetComponentsInChildren<Boss_Cible>();

        foreach (Boss_Cible Boss_Cible in Boss_Cibles)
        {
            Boss_Cible.DésactiverCible();
        }

        boss_Vie.RéinitialiserVie();

        boss_ApparitionCoeur.RéinitialiserValeur();
        

        this.gameObject.SetActive(true);
    }


    /// <summary>
    /// La méthode DésactiverBoss() permet de désactiver le Boss au grand complet.
    /// </summary>
    public void DésactiverBoss()
    {
        this.gameObject.SetActive(false);
    }
}
