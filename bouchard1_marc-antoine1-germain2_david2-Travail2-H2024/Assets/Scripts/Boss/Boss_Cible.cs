using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Boss_Cible permet de gérer une cible du Boss.
/// </summary>
public class Boss_Cible : MonoBehaviour
{
    [SerializeField] Boss_ApparitionCoeur Script_Boss_ApparitionCoeur; //Le script pour l'apparition du coeur du Boss.
    [SerializeField] Sprite TextureCibleAtteinte; //L'image affichée lorsque la cible est atteinte.

    Sprite TextureInitiale; //L'image affichée lorsque la cible n'est pas atteinte.
    SpriteRenderer SpriteRendererBoss;
    CircleCollider2D CircleCollider; //Le collider de la cible.

    bool cibleAtteinte = false; //Permet de savoir si la cible est atteinte

    void Start()
    {
        SpriteRendererBoss = GetComponent<SpriteRenderer>();
        CircleCollider = GetComponent<CircleCollider2D>();

        //On garde en mémoire la texture initiale de la cible.
        if (SpriteRendererBoss != null)
        {
            TextureInitiale = SpriteRendererBoss.sprite;
        }
    }


    /// <summary>
    /// La méthode OnTriggerEnter2D() permet de gérer les collisions entre la cible et l'extérieur, permet entre autres de désactiver la cible.
    /// </summary>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!cibleAtteinte)
        {
            CircleCollider.enabled = false;
            SpriteRendererBoss.sprite = TextureCibleAtteinte;

            collision.gameObject.SetActive(false);


            if (Script_Boss_ApparitionCoeur != null)
            {
                Script_Boss_ApparitionCoeur.AugmenterNbCiblesAtteintes();
            }
            cibleAtteinte = true;
        }
    }

    /// <summary>
    /// La méthode ActiverCible() permet d'activer la cible en question, c'est-à-dire, remettre en marche le collider et appliquer la texture initiale à la cible.
    /// </summary>
    public void ActiverCible()
    {
        if (CircleCollider != null)
        {
            CircleCollider.enabled = true;
        }
        if (SpriteRendererBoss != null)
        {
            SpriteRendererBoss.sprite = TextureInitiale;
        }
        cibleAtteinte = false;
    }

    /// <summary>
    /// La méthode DésactiverCible() permet de désactiver la cible, lors de la préparation du Boss (seulement la texture qui reste à celle initiale).
    /// </summary>
    public void DésactiverCible()
    {
        if (CircleCollider != null)
        {
            CircleCollider.enabled = false;
        }
        if (SpriteRendererBoss != null)
        {
            SpriteRendererBoss.sprite = TextureInitiale;
        }
    }
}
