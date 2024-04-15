using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// La classe ScoreAffichage permet de gérer l'affichage du score courant du Joueur, ainsi que son HighScore.
/// </summary>
public class ScoreAffichage : MonoBehaviour
{
    [SerializeField] TMP_Text pointDuJoueur;
    [SerializeField] TMP_Text HighScoreDuJoueur;
    // Start is called before the first frame update
    void Start()
    {
        pointDuJoueur.text = $"{PlayerPrefs.GetInt("Score")}";
        HighScoreDuJoueur.text = $"{PlayerPrefs.GetInt("HighScore")}";
    }
}
