using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// La classe Player_Mouvement permet de gérer le déplacement du player (gauche, droite, haut et bas) et aussi permet que le player ne dépasse pas la caméra de jeu.
/// </summary>
public class Player_Mouvement : MonoBehaviour
{
    [SerializeField] bool mouvementPlayerOn = true;
    [SerializeField] float vitesseDéplacement = 0.1f;
    [SerializeField] GameObject LimiteCoinHautGauche = null; //Limite de l'écran coin haut gauche.
    [SerializeField] GameObject LimiteCoinBasDroit = null; //Limite de l'écran coin bas droit.


    Vector2 AxeMouvementPlayer = Vector2.zero;

    public static Player_Mouvement Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        bool aDéjàBougé = false;

        //Permet de gérer le déplacement du player (gauche, droite, haut et bas) et aussi permet que le player ne dépasse pas la caméra de jeu:
        if (mouvementPlayerOn && AxeMouvementPlayer.magnitude > 0)
        {
            if ((transform.position.y + (-AxeMouvementPlayer.normalized.y * vitesseDéplacement * Time.deltaTime) > LimiteCoinHautGauche.transform.position.y))
            {
                transform.position = new Vector3(transform.position.x, LimiteCoinHautGauche.transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(AxeMouvementPlayer.x, 0, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseDéplacement * Time.deltaTime, Space.Self);
                aDéjàBougé = true;
            }
            if ((transform.position.y + (-AxeMouvementPlayer.normalized.y * vitesseDéplacement * Time.deltaTime) < LimiteCoinBasDroit.transform.position.y))
            {
                transform.position = new Vector3(transform.position.x, LimiteCoinBasDroit.transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(AxeMouvementPlayer.x, 0, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseDéplacement * Time.deltaTime, Space.Self);
                aDéjàBougé = true;
            }
            if ((transform.position.x + (-AxeMouvementPlayer.normalized.x * vitesseDéplacement * Time.deltaTime) > LimiteCoinHautGauche.transform.position.x))
            {
                transform.position = new Vector3(LimiteCoinHautGauche.transform.position.x, transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(0, AxeMouvementPlayer.y, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseDéplacement * Time.deltaTime, Space.Self);
                aDéjàBougé = true;
            }
            if ((transform.position.x + (-AxeMouvementPlayer.normalized.x * vitesseDéplacement * Time.deltaTime) < LimiteCoinBasDroit.transform.position.x))
            {
                transform.position = new Vector3(LimiteCoinBasDroit.transform.position.x, transform.position.y, transform.position.z);
                AxeMouvementPlayer = new Vector3(0, AxeMouvementPlayer.y, transform.position.z);
                transform.Translate(AxeMouvementPlayer.normalized * vitesseDéplacement * Time.deltaTime, Space.Self);
                aDéjàBougé = true;
            }

            if (!aDéjàBougé)
            {
                transform.Translate(AxeMouvementPlayer.normalized * vitesseDéplacement * Time.deltaTime, Space.Self);
            }

        }

    }


    /// <summary>
    /// La méthode SeDéplacer() permet de savoir si le joueur veut se déplacer ou non.
    /// </summary>
    /// <param name="context"></param>
    public void SeDéplacer(InputAction.CallbackContext context)
    {
        AxeMouvementPlayer = context.ReadValue<Vector2>();
    }

    public void SeDéplacerModeMobile(Vector2 axeMouvement)
    {
        AxeMouvementPlayer = axeMouvement;
    }
}
