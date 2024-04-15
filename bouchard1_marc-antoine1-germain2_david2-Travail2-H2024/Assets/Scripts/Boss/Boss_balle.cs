using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Boss_balle permet de gérer le mouvement des balles de l'attaque 1.
/// </summary>
public class Boss_balle : MonoBehaviour
{
    [SerializeField] float vitesseBalle = 0.1f;
    Vector2 AxeMouvementBalle = new Vector2(0, -1);

    //Permet de gérer le mouvement d'une balle d'attaque 1 du Boss:
    void Update()
    {
        transform.Translate(AxeMouvementBalle.normalized * vitesseBalle * Time.deltaTime, Space.Self);
    }
}
