using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Boss_Attaque1_laser permet de gérer l'attaque 1 du Boss.
/// </summary>
public class Boss_Attaque1_laser : MonoBehaviour
{
    //Les viseurs utilisés par Boss:
    [SerializeField] GameObject ViseurPrincipalGauche;
    [SerializeField] GameObject ViseurPrincipalDroite;
    [SerializeField] GameObject ViseurCoteGauche;
    [SerializeField] GameObject ViseurCoteDroite;

    [SerializeField] GameObject Balle; //Le Prefab utilisé pour les balles lors des attaques.
    [SerializeField] bool optionTir1 = false;
    [SerializeField] float nbDeTirsParSeconde = 1f;


    int compteurBalleAttaque1 = 0;
    float tirDélai = 0f;

    //L'attaque du Boss:
    void Update()
    {
        //Quand le délai est fini, l'attaque va pouvoir s'exécuter:
        if (tirDélai <= 0)
        {
            GameObject Balle1 = ObjectPool.Instance.GetPooledObject(Balle);

            if (Balle1 != null)
            {
                if (optionTir1)
                {
                    Balle1.gameObject.transform.position = ViseurPrincipalGauche.transform.position;
                    Balle1.gameObject.transform.rotation = ViseurPrincipalGauche.transform.rotation;
                }
                else
                {
                    Balle1.gameObject.transform.position = ViseurCoteGauche.transform.position;
                    Balle1.gameObject.transform.rotation = ViseurCoteGauche.transform.rotation;
                }
                Balle1.SetActive(true);
            }

            GameObject Balle2 = ObjectPool.Instance.GetPooledObject(Balle);

            if (Balle2 != null)
            {
                if (optionTir1)
                {
                    Balle2.gameObject.transform.position = ViseurPrincipalDroite.transform.position;
                    Balle2.gameObject.transform.rotation = ViseurPrincipalDroite.transform.rotation;
                }
                else
                {
                    Balle2.gameObject.transform.position = ViseurCoteDroite.transform.position;
                    Balle2.gameObject.transform.rotation = ViseurCoteDroite.transform.rotation;
                }
                Balle2.SetActive(true);
            }
            compteurBalleAttaque1++;
            tirDélai = 1f / nbDeTirsParSeconde;
        }
        tirDélai -= Time.deltaTime;


        //Changer l'option d'attaque (utiliser les viseurs principals ou les viseurs de côtés):
        if (compteurBalleAttaque1 == 3)
        {
            compteurBalleAttaque1 = 0;
            optionTir1 = !optionTir1;
        }
    }
}
