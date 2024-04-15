using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Boss_Attaque_3 permet de g�rer l'attaque 3 du Boss.
/// </summary>
public class Boss_Attaque_3 : MonoBehaviour
{
    [SerializeField] GameObject Balle = null; //Le GameObject Balle correspond au prefab utiliser pour faire apparaitre des balles.
    [SerializeField] GameObject ViseurTir = null; //Le GameObject ViseurTir correspond au prefab utilis� comme position o� nous allons faire apparaitre les balles.
    [SerializeField] float delaiEntreAttaques = 0.5f;
    float compteurProchaineAttaque = 0;

    float tirD�lai = 0f;
    [SerializeField] float nbDeTirsParSeconde = 3f;


    /// <summary>
    /// M�me principe que les autres attaques du boss, on tire, on attend que le timer soit �gale a une certaine valeur, on retire et ainsi de suite.
    /// </summary>
    void Update() 
    {
        if (tirD�lai <= 0)
        {
            ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -65));
            ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -50));
            ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -35));
            ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
            ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
            ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
            ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
            ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 35));
            ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 50));
            ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 65));

            tirD�lai = 1f / nbDeTirsParSeconde;

            compteurProchaineAttaque++;

            if (compteurProchaineAttaque == nbDeTirsParSeconde)
            {
                compteurProchaineAttaque = 0;
                tirD�lai = delaiEntreAttaques;
            }
        }
        tirD�lai -= Time.deltaTime;
    }/// <summary>
     /// m�me principe que pour le joueur, on va chercher une balle (prefab) dans l'object bool
     /// </summary>
     /// <param name="AxeXPosition">La position en x de la balle</param>
     /// <param name="rotation">La rotation de la balle pour �viter de juste tirer en ligne droite</param>
    private void ObtenirBalle(float AxeXPosition, Vector3 rotation)
    {
        GameObject InstanceBalle = ObjectPool.Instance.GetPooledObject(Balle);
        if (InstanceBalle != null)
        {
            InstanceBalle.SetActive(true);
            InstanceBalle.transform.position = new Vector3(AxeXPosition, ViseurTir.transform.position.y, ViseurTir.transform.position.z);
            InstanceBalle.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
