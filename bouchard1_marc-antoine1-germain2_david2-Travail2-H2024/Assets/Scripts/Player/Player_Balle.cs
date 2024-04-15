using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Player_Balle permet de g�rer le d�placement des balles du Player.
/// </summary>
public class Player_Balle : MonoBehaviour
{    
    [SerializeField] float vitesseD�placement = 1f;

    void Update()
    {
        //Permet de g�rer le d�placement des balles:
        transform.Translate(new Vector2(0, 1).normalized * vitesseD�placement * Time.deltaTime, Space.Self);
    }

}
