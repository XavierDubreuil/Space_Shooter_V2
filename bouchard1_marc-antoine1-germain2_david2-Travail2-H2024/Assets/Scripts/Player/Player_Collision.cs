using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Player_Collision permet de gérer les collisions entre le player et les autres objets.
/// </summary>
public class Player_Collision : MonoBehaviour
{
    [SerializeField] Player_NbreVies Player_NombreDeVies_Script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de gérer les collisions entre le player et les autres objets:
        if (Player_NombreDeVies_Script != null && !collision.gameObject.CompareTag("Balle_Player"))
        {
            if (!collision.gameObject.CompareTag("Vie") && !collision.gameObject.CompareTag("Shield"))
            {
                if (Player_NombreDeVies_Script.shield)
                    Player_NombreDeVies_Script.DésactiverShield();
                else
                    Player_NombreDeVies_Script.DiminuerVie();
            }
            else if (collision.gameObject.CompareTag("Vie"))
                Player_NombreDeVies_Script.AugmenterVie();
            else if (!Player_NombreDeVies_Script.shield)
                Player_NombreDeVies_Script.ActiverShield();

            collision.gameObject.SetActive(false);
        }
    }
}
