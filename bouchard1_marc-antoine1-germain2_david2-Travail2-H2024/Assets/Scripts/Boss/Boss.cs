using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// La classe Boss permet de g�rer les �l�ments g�n�rales du Boss. En effet, il permet de pr�parer le Boss, de choisir une attaque au hasard,
/// de r�initialiser le Boss et permet de d�sactiver le Boss au grand complet. 
/// </summary>
public class Boss : MonoBehaviour
{
    [SerializeField] GameObject PositionInitiale; //Corrspond � la position initiale � la quelle le Boss va apparaitre
    [SerializeField] GameObject PositionFinale; //Correspond � la position finale du Boss

    [SerializeField] Boss_Attaque1_laser Script_Attaque1; //Script pour l'attaque 1
    [SerializeField] bullet_hell ScriptBullet_hell; //Script pour l'attaque 2
    [SerializeField] Boss_Attaque_3 Script_Attaque3; //Script pour l'attaque 3

    [SerializeField] Boss_Vie boss_Vie;
    [SerializeField] Boss_ApparitionCoeur boss_ApparitionCoeur;

    [SerializeField] AudioSource boss_spawn; //Le son que le Boss fait lorsque le Boss apparait.
    
    [SerializeField] Canvas lifeBar; //Est un canvas utilis� sp�cialement pour la barre de vie du Boss
    [SerializeField] Slider slider_Health; //La barre de vie du Boss


    float vitesseBossPr�paration = 1f; //La vitesse de d�placement du Boss lors de la pr�paration avant l'attaque.

    bool estArriv�PositionFinale = false; //Permet de savoir si le Boss est arriv� � la position finale (s'il a fini sa pr�paration)


    bool aChoisitAttaque = false; //Permet de savoir si le Boss a d�j� fini son attaque.


    Boss_Cible[] Boss_Cibles; //Comprend toutes les cibles du Boss.

    void Start()
    {
        slider_Health.maxValue = boss_Vie.nbViesCourantes; //Initialiser la valeur maximale de la barre de vie
        slider_Health.value = 3f; //Mettre une valeur par d�faut � la barre de vie.
        boss_spawn.Stop(); //S'assurer que le son d'apparition est arr�t�.

        transform.position = PositionInitiale.transform.position; //On donne une position par d�faut au Boss

        Boss_Cibles = GetComponentsInChildren<Boss_Cible>();

        foreach (Boss_Cible Boss_Cible in Boss_Cibles)
        {
            Boss_Cible.D�sactiverCible();
        }
    }

    //Permet de g�rer l'apparition du Boss ainsi que son attaque (il n'a que 1 attaque par apparition):
    void Update()
    {
        if (boss_Vie.EstVivant())
        {
            slider_Health.value = boss_Vie.nbViesCourantes; //Permet de mettre � jour la barre de vie du Boss.
            if (estArriv�PositionFinale)
            {
                //Lorsque le Boss est arriv� � la position finale (suite � la pr�paration) et qu'il n'a pas encore choisit son attaque:
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
                //Lorsque le Boss va � la position finale (lors de la pr�paration):

            
                if (Player_g�rerSon.Instance.SonEstActiv�())
                    boss_spawn.Play();
                lifeBar.enabled = true;

                //Pr�paration vers la position finale:
                Pr�paration();
                V�rifierPosition();
            }
        }
    }
    /// <summary>
    /// La m�thode Pr�paration() permet de diriger le Boss vers la position finale.
    /// </summary>
    private void Pr�paration()
    {
        transform.Translate(new Vector2(0, -1).normalized * vitesseBossPr�paration * Time.deltaTime, Space.Self);
    }

    /// <summary>
    /// La m�thode V�rifierPosition() permet de v�rifier si le Boss est arriv� � la position finale. Si il est arriv�, la m�thode active alors les cibles.
    /// </summary>
    private void V�rifierPosition()
    {
        if (transform.position.y <= PositionFinale.transform.position.y)
        {
            estArriv�PositionFinale = true;
            foreach (Boss_Cible Boss_Cible in Boss_Cibles)
            {
                Boss_Cible.ActiverCible();
            }
        }
    }

    /// <summary>
    /// La m�thode Attaque1() permet de g�rer l'ex�cution du script qui concerne l'attaque 1 du Boss.
    /// </summary>
    private void Attaque1()
    {
        if (!Script_Attaque1.enabled)
            Script_Attaque1.enabled = true;
    }

    /// <summary>
    /// La m�thode Attaque2() permet de g�rer l'ex�cution du script qui concerne l'attaque 2 du Boss.
    /// </summary>
    private void Attaque2()
    {
        if (!ScriptBullet_hell.enabled)
            ScriptBullet_hell.enabled = true;
    }
    /// <summary>
    ///  La m�thode Attaque3() permet de g�rer l'ex�cution du script qui concerne l'attaque 3 du Boss.
    /// </summary>
    private void Attaque3()
    {
        if (!Script_Attaque3.enabled)
            Script_Attaque3.enabled = true;
    }

    /// <summary>
    /// La m�thode ObtenirTypeAttaqueHasard() permet d'obtenir une attaque au hasard.
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
    /// La m�thode R�initialiserValeur() permet de r�initialiser les valeurs du boss afin de reprendre du d�but comme si s'�tait un nouveau Boss.
    /// </summary>
    public void R�initialiserValeur()
    {
        transform.position = PositionInitiale.transform.position;
        transform.rotation = Quaternion.EulerRotation(0, 0, 0);


        Script_Attaque1.enabled = false;
        ScriptBullet_hell.enabled = false;

        estArriv�PositionFinale = false;
        aChoisitAttaque = false;

        Boss_Cibles = GetComponentsInChildren<Boss_Cible>();

        foreach (Boss_Cible Boss_Cible in Boss_Cibles)
        {
            Boss_Cible.D�sactiverCible();
        }

        boss_Vie.R�initialiserVie();

        boss_ApparitionCoeur.R�initialiserValeur();
        

        this.gameObject.SetActive(true);
    }


    /// <summary>
    /// La m�thode D�sactiverBoss() permet de d�sactiver le Boss au grand complet.
    /// </summary>
    public void D�sactiverBoss()
    {
        this.gameObject.SetActive(false);
    }
}
