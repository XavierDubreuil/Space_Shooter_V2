using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// La classe Player_Tirer permet de gérer les tirs de balles du Player.
/// </summary>
public class Player_Tirer : MonoBehaviour
{
    [SerializeField] bool tirerOn = true;
    [SerializeField] GameObject Balle = null; //Le GameObject Balle correspond au prefab utiliser pour faire apparaitre des balles.
    [SerializeField] float nbBallesParSeconde = 5f; //Le nombre de balle tiré par seconde.
    [SerializeField] GameObject ViseurTir = null; //Le GameObject ViseurTir correspond au prefab utilisé comme position où nous allons faire apparaitre les balles.
    [SerializeField] Player_NbreVies Player_NombreDeVies_Script;
    [SerializeField] AudioSource SonTirer;

    float tire = 0;
    float tireDélai = 0;


    bool estMobile = false;



    void Start()
    {
        SonTirer.Stop();
    }

    void Update()
    {
        //Permet de gérer les tirs du Player:
        if (tirerOn && Balle != null && ViseurTir != null && tire > 0 && tireDélai <= 0)
        {
            switch (Player_NombreDeVies_Script.NombreDeVies)
            {
                case 1:
                    ObtenirBalle(ViseurTir.transform.position.x, new Vector3(0, 0, 0));
                    break;
                case 2:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, 0));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 0));
                    break;
                case 3:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x, new Vector3(0, 0, 0));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 5));
                    break;
                case 4:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
                    break;
                case 5:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x, new Vector3(0, 0, 0));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
                    break;
                case 6:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -35));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 35));
                    break;
                case 7:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -35));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x, new Vector3(0, 0, 0));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 35));
                    break;
                case 8:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -50));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -35));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 35));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 50));
                    break;
                case 9:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -50));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -35));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -20));
                    ObtenirBalle(ViseurTir.transform.position.x + 0.2f, new Vector3(0, 0, -5));
                    ObtenirBalle(ViseurTir.transform.position.x, new Vector3(0, 0, 0));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 5));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 20));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 35));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.2f, new Vector3(0, 0, 50));
                    break;
                case 10:
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
                    break;

                default:
                    ObtenirBalle(ViseurTir.transform.position.x + 0.3f, new Vector3(0, 0, -45));
                    ObtenirBalle(ViseurTir.transform.position.x, new Vector3(0, 0, 0));
                    ObtenirBalle(ViseurTir.transform.position.x - 0.3f, new Vector3(0, 0, 45));
                    break;
            }
            tireDélai = 1f / nbBallesParSeconde;

            if (estMobile)
            {
                estMobile = false;
                tire = 0;
            }

            tireDélai = 1f/nbBallesParSeconde;
            if (Player_gérerSon.Instance.SonEstActivé())
                SonTirer.Play();

        }
        tireDélai -= Time.deltaTime;
    }

    /// <summary>
    /// La méthode ObtenirBalle() permet d'obtenir un objet Balle et de définir une position et une rotation en particulier.
    /// </summary>
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

    /// <summary>
    /// La méthode Tirer() permet de déterminer si le Player tire ou non.
    /// </summary>
    /// <param name="context"></param>
    public void Tirer(InputAction.CallbackContext context)
    {
        tire = context.ReadValue<float>();
        estMobile = false;
    }

    public void TirerMobile()
    {
        tire = 1;
        estMobile = true;
    }
}
