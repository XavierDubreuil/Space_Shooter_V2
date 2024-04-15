using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// La classe Player_NbreVies permet de gérer le nombre de vies du Player.
/// </summary>
public class Player_NbreVies : MonoBehaviour
{
    const float NBR_DE_VIES_MAX = 10;
    public float NombreDeVies { get; private set; } = 1f;

    SpriteRenderer spriteRenderer;
    public bool shield { get; private set; } = false;

    [SerializeField] int idSceneFinal = 2;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    /// <summary>
    /// La méthode AugmenterVie() permet d'augmenter les vies d'un joueur.
    /// </summary>
    public void AugmenterVie()
    {
        if (NombreDeVies != NBR_DE_VIES_MAX)
            NombreDeVies++;
    }

    /// <summary>
    /// La méthode DiminuerVie() permet de diminuer les vies d'un joueur.
    /// </summary>
    public void DiminuerVie()
    {
        if (NombreDeVies != 0)
        {
            NombreDeVies--;
            if (NombreDeVies == 0)
            {
                if(PlayerPrefs.HasKey("HighScore"))
                {
                    if (PlayerPrefs.GetInt("HighScore") < Score.Instance.score) //Si la valeur du score actuel est plus grande, alors on change le High Score
                    {
                        PlayerPrefs.SetInt("HighScore", Score.Instance.score);    // Change ou ajoute une valeur dans un dictionnaire
                        PlayerPrefs.Save();
                    }
                } 
                else
                {
                    PlayerPrefs.SetInt("HighScore", Score.Instance.score);    // Change ou ajoute une valeur dans un dictionnaire
                    PlayerPrefs.Save();
                }
                PlayerPrefs.SetInt("Score", Score.Instance.score);    // On met la valeur du score dans le playerPref pour l'utiliser sur la page de fin
                PlayerPrefs.Save();
                SceneManager.LoadScene(idSceneFinal);
            }
               
        }
    }
    //Permet d'activer le shield et donc d'offrir "une vie en plus"
    public void ActiverShield()
    {
        spriteRenderer.color = Color.cyan;
        shield = true;
    }
    //Remplace la perte d'une vie lorsque touché et que le shield est actif
    public void DésactiverShield()
    {
        spriteRenderer.color = Color.white;
        shield = false;
    }
}
