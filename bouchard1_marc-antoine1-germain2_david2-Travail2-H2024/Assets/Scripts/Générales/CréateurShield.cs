using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe CréateurShield permet de gérer la création d'objet Shield.
/// </summary>
public class CréateurShield : MonoBehaviour
{
    [SerializeField] GameObject LimiteCoinGaucheApparition = null;
    [SerializeField] GameObject LimiteCoinDroitApparition = null; 
    [SerializeField] GameObject Shield = null;

    float tempsÉcoulé = 0f; //Temps écoulé depuis la dernière apparition d'un objet shield.
    float tempsÉcouléMax = 6f; //Le temps que doit atteindre la variable tempsÉcoulé pour faire apparaitre un objet shield.

    public void Update()
    {
        //Pour faire apparaitre l'objetShield:
        if (tempsÉcoulé >= tempsÉcouléMax)
        {
            CréerShield();
            tempsÉcoulé = 0;
        }
        tempsÉcoulé += Time.deltaTime; //Permet de gérer le temps écoulé depuis la dernière apparition d'un objet 1Up.
    }

    /// <summary>
    /// La méthode CréerShield() permet de gérer l'apparition d'un objet 1Up (ainsi que sa rotation et sa position).
    /// </summary>
    private void CréerShield()
    {
        if (LimiteCoinGaucheApparition != null && LimiteCoinDroitApparition != null)
        {
            float x = Random.Range(LimiteCoinGaucheApparition.transform.position.x, LimiteCoinDroitApparition.transform.position.x);
            GameObject shield = ObjectPool.Instance.GetPooledObject(Shield);
            if (shield != null)
            {
                shield.transform.position = new Vector2(x, LimiteCoinGaucheApparition.transform.position.y);
                shield.transform.rotation = LimiteCoinGaucheApparition.transform.rotation;
                shield.SetActive(true);
            }
        }
    }
}
