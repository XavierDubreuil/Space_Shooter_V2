using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Player_Balle permet de gérer le déplacement des balles du Player.
/// </summary>
public class Player_Balle : MonoBehaviour
{    
    [SerializeField] float vitesseDéplacement = 1f;

    void Update()
    {
        //Permet de gérer le déplacement des balles:
        transform.Translate(new Vector2(0, 1).normalized * vitesseDéplacement * Time.deltaTime, Space.Self);
    }

}
