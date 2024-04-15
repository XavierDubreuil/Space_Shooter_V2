using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// La classe Ennemi_Balle s'occupe du mouvement de la balle d'un ennemi
/// </summary>
public class Ennemi_Balle : MonoBehaviour
{
    [SerializeField] float vitesseD�placement;
    void Update()
    {
        transform.Translate(transform.forward * vitesseD�placement * Time.deltaTime, Space.World);     //Puisque la rotation est instanci�e au d�part, un .foward suffit. (Transform.forward d�place le GameObject tout en tenant compte de sa rotation.)
    }
}
