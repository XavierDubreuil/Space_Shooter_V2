using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// La classe Player_Mouvement permet de g�rer le d�placement du player (gauche, droite, haut et bas) et aussi permet que le player ne d�passe pas la cam�ra de jeu.
/// </summary>
public class Player_Mouvement : MonoBehaviour
{
    [SerializeField] bool mouvementPlayerOn = true;
    [SerializeField] float vitesseD�placement = 0.1f;
    [SerializeField] GameObject LimiteCoinHautGauche = null; //Limite de l'�cran coin haut gauche.
    [SerializeField] GameObject LimiteCoinBasDroit = null; //Limite de l'�cran coin bas droit.


    Vector2 AxeMouvementPlayer = Vector2.zero;

    public static Player_Mouvement Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        bool aD�j�Boug� = false;

        //Permet de g�rer le d�placement du player (gauche, droite, haut et bas) et aussi permet que le player ne d�passe pas la cam�ra de jeu:
        if (mouvementPlayerOn && AxeMouvementPlayer.magnitude > 0)
        {
            if ((transform.position.y + (-AxeMouvementPlayer.normalized.y * vitesseD�placement * Time.deltaTime) > LimiteCoinHautGauche.transform.position.y))
            {
                transform.position = new Vector3(transform.position.x, LimiteCoinHautGauche.transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(AxeMouvementPlayer.x, 0, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseD�placement * Time.deltaTime, Space.Self);
                aD�j�Boug� = true;
            }
            if ((transform.position.y + (-AxeMouvementPlayer.normalized.y * vitesseD�placement * Time.deltaTime) < LimiteCoinBasDroit.transform.position.y))
            {
                transform.position = new Vector3(transform.position.x, LimiteCoinBasDroit.transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(AxeMouvementPlayer.x, 0, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseD�placement * Time.deltaTime, Space.Self);
                aD�j�Boug� = true;
            }
            if ((transform.position.x + (-AxeMouvementPlayer.normalized.x * vitesseD�placement * Time.deltaTime) > LimiteCoinHautGauche.transform.position.x))
            {
                transform.position = new Vector3(LimiteCoinHautGauche.transform.position.x, transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(0, AxeMouvementPlayer.y, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseD�placement * Time.deltaTime, Space.Self);
                aD�j�Boug� = true;
            }
            if ((transform.position.x + (-AxeMouvementPlayer.normalized.x * vitesseD�placement * Time.deltaTime) < LimiteCoinBasDroit.transform.position.x))
            {
                transform.position = new Vector3(LimiteCoinBasDroit.transform.position.x, transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(0, AxeMouvementPlayer.y, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseD�placement * Time.deltaTime, Space.Self);
                aD�j�Boug� = true;
            }

            if (!aD�j�Boug�)
            {
                transform.Translate(AxeMouvementPlayer.normalized * vitesseD�placement * Time.deltaTime, Space.Self);
            }

        }

    }


    /// <summary>
    /// La m�thode SeD�placer() permet de savoir si le joueur veut se d�placer ou non.
    /// </summary>
    /// <param name="context"></param>
    public void SeD�placer(InputAction.CallbackContext context)
    {
        AxeMouvementPlayer = context.ReadValue<Vector2>();
    }

    public void SeD�placerModeMobile(Vector2 axeMouvement)
    {
        AxeMouvementPlayer = axeMouvement;
    }
}
