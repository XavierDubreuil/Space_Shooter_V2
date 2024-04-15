using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Boss_DiminuerVies permet de gérer le nombre de vies du Boss (gère le coeur du Boss).
/// </summary>
public class Boss_DiminuerVies : MonoBehaviour
{
    [SerializeField] Boss_Vie Boss_Vie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Boss_Vie != null)
        {
            Boss_Vie.DiminuerVie();
            if (collision.gameObject.tag == "Balle_Player")
                collision.gameObject.SetActive(false);
        }
    }
}
