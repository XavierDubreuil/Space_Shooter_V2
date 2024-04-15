using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Background_Mouvement s'occupe du mouvement et de la gestion du background
/// </summary>
public class Background_Mouvement : MonoBehaviour
{
    [SerializeField] float vitesse = 2;
    Vector3 posRéapparition;
    void Start()
    {
        //Trouve la position du backgroud Haut pour pouvoir remmettre la position des background correctement lorsque le background du bas est trop bas.
        posRéapparition = GameObject.FindGameObjectWithTag("Background_Haut").transform.position;
    }

    void Update()
    {
        //Mouvement vers le bas du background
        transform.Translate(new Vector3(0,-1,0) * vitesse * Time.deltaTime, Space.Self);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //S'assure que lorsque le background est trop bas, de le remmettre à la position déterminée au start (à la position initiale du background du haut).
        transform.position = posRéapparition;
    }
}
