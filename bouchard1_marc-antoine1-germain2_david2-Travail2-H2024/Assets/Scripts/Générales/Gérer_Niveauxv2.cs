using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Le scripte sert de gérer les vagues d'ennemis en général
public class Gérer_Niveauxv2 : MonoBehaviour
{
    [SerializeField] Boss boss;

    CréateurEnnemi1 créateurEnnemi1;
    CréateurEnnemi2 créateurEnnemi2;

    Canvas canvas;
    [SerializeField] TextMeshProUGUI WaveIndicator;

    //Les premières vagues prédéfinies
    (int nb_groupe_ennemi_2, int min_ennemi2_par_groupe, int max_ennemi2_par_groupe, float delai_apparition, float vitesse, float vitesse_tir)[] tabWaves2 =
        new (int nb_groupe_ennemi_2, int min_ennemi2_par_groupe, int max_ennemi2_par_groupe, float delai_apparition, float vitesse, float vitesse_tir)[6]; //Pour la gestion des ennemi2

    (int nb_groupe_ennemi_1, float delai_apparition, float vitesse)[] tabWaves =
        new (int nb_groupe_ennemi_1, float delai_apparition, float vitesse)[6]; //Pour la gestion des ennemi1


    int compteurWave = 0;
    float compteurWaveIndicator = 0; //Permet de gérer l'apparition du text qui dit à quel vague d'ennemi nous sommes rendus.
    bool WavesReady = true;

    bool waveEstBoss = false;


    int apparitionBoss = 3; //Permet de dire a quelle wave nous voulons faire apparaitre le boss. (voir modulo) (Ex: 0 == Wave 1, 1 == Wave 2)

    void Start()
    {
        //Les premières vagues prédéfinies
        créateurEnnemi1 = GetComponent<CréateurEnnemi1>();
        créateurEnnemi2 = GetComponent<CréateurEnnemi2>();
        tabWaves2[0] = (2, 1, 2, 8f, 1f, 5); //Wave1 Ennemi2
        tabWaves2[1] = (4, 1, 3, 7f, 2f, 4); //Wave2 Ennemi2
        tabWaves2[2] = (5, 1, 3, 5f, 2.5f, 4); //Wave3 Ennemi2
        tabWaves2[3] = (0, 0, 0, 0, 0, 0); //Wave4 -------------- BOSS
        tabWaves2[4] = (6, 1, 4, 5f, 3f, 3); //Wave4 Ennemi2
        tabWaves2[5] = (6, 1, 5, 4f, 3.5f, 2); //Wave5 Ennemi2
        tabWaves[0] = (10, 0, 3f); //Wave1 Ennemi1
        tabWaves[1] = (14, 1, 4f); //Wave2 Ennemi1
        tabWaves[2] = (20, 0.5f, 5f); //Wave3 Ennemi1
        tabWaves[3] = (0, 0, 0); //Wave4 ------------ BOSS
        tabWaves[4] = (25, 0.5f, 6f); //Wave4 Ennemi1
        tabWaves[5] = (35, 0.5f, 7f); //Wave5 Ennemi1

        boss.DésactiverBoss();
    }

    void Update()
    {

        //Lance la prochaine vague si elle est prête à être lancé
        if (WavesReady)
        {
            compteurWaveIndicator = 0;
            WavesReady = false;

            if (compteurWave % apparitionBoss != 0 || compteurWave == 0)
            {

                int indexTabWave = compteurWave;
                if (compteurWave > tabWaves.Length-1)
                {
                    indexTabWave = tabWaves.Length - 1;
                }
                WaveIndicator.SetText("Wave " + (compteurWave + 1));
                WaveIndicator.enabled = true;
                //Envoyer de nouvelles informations aux scripts qui gèrent la création d'ennemis pour qu'il crée différament les ennemis selon les niveaux:
                créateurEnnemi2.newWave(tabWaves2[indexTabWave].nb_groupe_ennemi_2, tabWaves2[indexTabWave].min_ennemi2_par_groupe, tabWaves2[indexTabWave].max_ennemi2_par_groupe, tabWaves2[indexTabWave].delai_apparition, tabWaves2[indexTabWave].vitesse, tabWaves2[indexTabWave].vitesse_tir);
                créateurEnnemi1.newWave(tabWaves[indexTabWave].nb_groupe_ennemi_1, tabWaves[indexTabWave].delai_apparition, tabWaves[indexTabWave].vitesse);
            }
            else
            {

                WaveIndicator.SetText("Wave " + (compteurWave + 1) + " - Boss");
                WaveIndicator.enabled = true;
                if (!boss.enabled)
                {
                    boss.enabled = true;
                } 
                
                waveEstBoss = true;
                boss.RéinitialiserValeur();
            }
        }
        //Gère le temps d'apparition de l'indicateur de waves:
        if (compteurWaveIndicator >= 5)
        {
            WaveIndicator.enabled = false;
        }
        //On attend que tout les ennemis ont été affiché avant de passer à la prochaine wave:
        if ((créateurEnnemi1.apparition_finie && créateurEnnemi2.apparition_finie && ObjectPool.Instance.AllEnnemisDisponible() && !waveEstBoss) || (waveEstBoss && !boss.EstVivant()))
        {
            compteurWave++;
            WavesReady = true;
            waveEstBoss = false;
        }


        compteurWaveIndicator += Time.deltaTime;
    }
}
