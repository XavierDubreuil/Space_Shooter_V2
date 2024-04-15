using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// La classe bullet_hell permet de g�rer la deuxi�me attaque du Boss. C'est une attaque d�vastatrice du boss
/// </summary>
public class bullet_hell : MonoBehaviour
{
    [SerializeField] float delaiEntreBalles = 0.5f;
    [SerializeField] float delaiEntreAttaques = 5f;
    [SerializeField] float dur�eAttaque = 2f;
    [SerializeField] GameObject Balle = null; //C'est le prefab de la balle qui va �tre utilis�.
    [SerializeField] float vitesseRotation = 100;
    float compteurProchaineAttaque = 0;
    float compteurBalles = 0;
    float compteurAttaqueActuelle = 0;
    bool attaqueBulletHell = false;
    Quaternion rotationOrigine;

    private void OnEnable()
    {
        rotationOrigine = transform.rotation;
    }
    void Update()
    {
        //Attaque selon un d�lai
        if (attaqueBulletHell)
        {
            //Tourne le boss
            transform.Rotate(new Vector3(0, 0, 1) * vitesseRotation * Time.deltaTime);
            //Initialise toutes les balles
            if (compteurBalles > delaiEntreBalles)
            {
                compteurBalles = 0;
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, 90));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, -90));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, 180));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, 45));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, -45));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, 135));
                ObtenirBalle(transform.rotation.eulerAngles + new Vector3(0, 0, -135));
            }
            else
            {
                compteurBalles += Time.deltaTime;
            }

            //G�re le temps de l'attaque
            if(compteurAttaqueActuelle >= dur�eAttaque)
            {
                attaqueBulletHell = false;
                transform.rotation = rotationOrigine;
                compteurAttaqueActuelle = 0;
            }
            else
            {
                compteurAttaqueActuelle += Time.deltaTime;
            }
        }
        else
        {
            //V�rifie si le boss doit lanc� sa prochaine attaque
            if (compteurProchaineAttaque >= delaiEntreAttaques && !attaqueBulletHell)
            {
                attaqueBulletHell = true;
                compteurBalles = delaiEntreBalles;
                compteurProchaineAttaque = 0;
            }
            else
            {
                compteurProchaineAttaque += Time.deltaTime;
            }
        }
    }
    //Sert � instancier une balle
    private void ObtenirBalle(Vector3 rotation)
    {
        GameObject InstanceBalle = ObjectPool.Instance.GetPooledObject(Balle);
        if (InstanceBalle != null)
        {
            InstanceBalle.SetActive(true);
            InstanceBalle.transform.position = transform.position;
            InstanceBalle.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
