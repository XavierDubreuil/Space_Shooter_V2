using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Balle_Collision permet de gérer la collision des balles.
/// </summary>
public class Balle_Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de désactiver les objets qui rentre en collision entre eux:
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Balle_Ennemi2") && !collision.gameObject.CompareTag("Cible_Boss"))
        {            
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            Score.Instance.AugmenterScore();
        }
    }
}
