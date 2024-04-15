using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// La classe Ennemi_Balle s'occupe du mouvement de la balle d'un ennemi
/// </summary>
public class Ennemi_Balle : MonoBehaviour
{
    [SerializeField] float vitesseDéplacement;
    void Update()
    {
        transform.Translate(transform.forward * vitesseDéplacement * Time.deltaTime, Space.World);     //Puisque la rotation est instanciée au départ, un .foward suffit. (Transform.forward déplace le GameObject tout en tenant compte de sa rotation.)
    }
}
