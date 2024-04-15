using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModesDuJeu : MonoBehaviour
{
    [SerializeField] Button btnAttaquer;
    [SerializeField] Toggle toglleModeDeJeu;
    [SerializeField] Image joystick;
    [SerializeField] Image joystickDeplacement;

    bool estMobile = false;

    bool aTouch�Ecran = false;

    float temps�coul�Touche = 0;
    void Start()
    {
        EstMobile();
        if (joystick != null && joystickDeplacement != null)
        {
            joystick.gameObject.SetActive(false);
            joystickDeplacement.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        bool estBoutonPremierDoigt = false;

        if (estMobile && Input.touchCount > 0 && !estBoutonPremierDoigt)
        {
            //Voici le lien o� nous avons trouv� l'information suivante: https://stackoverflow.com/questions/39150165/how-do-i-find-which-object-is-eventsystem-current-ispointerovergameobject-detect
            Touch toucheJoyStick = Input.GetTouch(0);

            PointerEventData pointeur = new PointerEventData(EventSystem.current);
            pointeur.position = Input.GetTouch(0).position;

            List<RaycastResult> raycastResultats = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointeur, raycastResultats);

            if (raycastResultats.Count > 0)
            {
                foreach (var raycastResultat in raycastResultats)
                {
                    if (raycastResultat.gameObject.name == "BtnAttaquer" || raycastResultat.gameObject.tag == "checkbox_modeMobile")                    
                        estBoutonPremierDoigt = true;                    
                }
            }

            if (Input.touchCount > 1)
            {
                pointeur.position = Input.GetTouch(1).position;

                List<RaycastResult> raycastResultat2 = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointeur, raycastResultat2);

                if (raycastResultat2.Count == 0)                
                    toucheJoyStick = Input.GetTouch(1);                
            }


            if (!estBoutonPremierDoigt || Input.touchCount > 1)
            {
                if (joystick != null && joystickDeplacement != null && !aTouch�Ecran)
                {
                    joystick.gameObject.transform.position = toucheJoyStick.position;
                    joystick.gameObject.SetActive(true);

                    joystickDeplacement.gameObject.transform.position = toucheJoyStick.position;
                    joystickDeplacement.gameObject.SetActive(true);

                    aTouch�Ecran = true;
                }
                else if (joystick != null && joystickDeplacement != null && aTouch�Ecran)
                {
                    //https://docs.unity3d.com/ScriptReference/Vector3.Distance.html (pour la distance entre deux points):
                    Vector2 distanceJoyStickDeplacement = Vector3.zero;

                    Vector2 positionInitiale = new Vector2(toucheJoyStick.position.x - joystick.gameObject.transform.position.x, toucheJoyStick.position.y - joystick.gameObject.transform.position.y);


                    if (Vector3.Distance(toucheJoyStick.position, joystick.gameObject.transform.position) > 32f)
                    {

                        float mag = positionInitiale.magnitude;

                        float x = (positionInitiale.x * 32f) / mag;
                        float y = (positionInitiale.y * 32f) / mag;


                        Vector2 positionFinale = new Vector2(joystick.gameObject.transform.position.x + x, joystick.gameObject.transform.position.y + y);


                        distanceJoyStickDeplacement = positionFinale;

                    }
                    else
                    {
                        distanceJoyStickDeplacement = toucheJoyStick.position;
                    }

                    Vector2 axeDeplacement = new Vector2(positionInitiale.x, -positionInitiale.y);
                    Player_Mouvement.Instance.SeD�placerModeMobile(axeDeplacement.normalized);


                    joystickDeplacement.gameObject.transform.position = distanceJoyStickDeplacement;

                }
            }
        }
        else
        {
            if (joystick != null && joystickDeplacement != null)
            {
                joystick.gameObject.SetActive(false);
                joystickDeplacement.gameObject.SetActive(false);
            }
            aTouch�Ecran = false;

            //Si on est en mode mobile et que la derni�re action �tait un d�placement, on doit remettre l'axe de d�placement � un vecteur de 0.
            if (estMobile)
            {
                Player_Mouvement.Instance.SeD�placerModeMobile(Vector2.zero);
            }
        }
    }

    public void EstMobile()
    {
        estMobile = toglleModeDeJeu.isOn;

        if (btnAttaquer != null)
        {
            btnAttaquer.gameObject.SetActive(estMobile);
        }
    }
}
