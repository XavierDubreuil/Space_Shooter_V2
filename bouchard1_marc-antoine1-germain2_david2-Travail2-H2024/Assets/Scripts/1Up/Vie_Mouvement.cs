using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Vie_Mouvement permet de gérer le déplacement d'une vie.
/// </summary>
public class Vie_Mouvement : MonoBehaviour
{
    [SerializeField] float vitesseDéplacement = 1f;
    [SerializeField] bool déplaceOn = true;

    void Update()
    {
        //Permet le déplacement de la vie:
        if (déplaceOn)
            transform.Translate(new Vector3(0, -1, 0).normalized * vitesseDéplacement * Time.deltaTime);
    }
}
