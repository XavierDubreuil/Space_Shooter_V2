using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Vie_Mouvement permet de g�rer le d�placement d'une vie.
/// </summary>
public class Vie_Mouvement : MonoBehaviour
{
    [SerializeField] float vitesseD�placement = 1f;
    [SerializeField] bool d�placeOn = true;

    void Update()
    {
        //Permet le d�placement de la vie:
        if (d�placeOn)
            transform.Translate(new Vector3(0, -1, 0).normalized * vitesseD�placement * Time.deltaTime);
    }
}
