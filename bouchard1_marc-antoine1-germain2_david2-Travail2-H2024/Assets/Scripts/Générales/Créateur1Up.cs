using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Créateur1Up permet de gérer la création d'objet 1Up.
/// </summary>
public class Créateur1Up : MonoBehaviour
{
    [SerializeField] GameObject LimiteCoinGaucheApparition = null;
    [SerializeField] GameObject LimiteCoinDroitApparition = null; 
    [SerializeField] GameObject ObjetVie = null;

    float tempsÉcoulé = 0f; //Temps écoulé depuis la dernière apparition d'un objet 1Up.
    float tempsÉcouléMax = 8f; //Le temps que doit atteindre la variable tempsÉcoulé pour faire apparaitre un objet vie.

    public void Update()
    {
        //Pour faire apparaitre l'objet 1Up:
        if (tempsÉcoulé >= tempsÉcouléMax)
        {
            Créer1Up();
            tempsÉcoulé = 0;
            tempsÉcouléMax += 10f;
        }
        tempsÉcoulé += Time.deltaTime; //Permet de gérer le temps écoulé depuis la dernière apparition d'un objet 1Up.
    }

    /// <summary>
    /// La méthode Créer1Up() permet de gérer l'apparition d'un objet 1Up (ainsi que sa rotation et sa position).
    /// </summary>
    private void Créer1Up()
    {
        if (LimiteCoinGaucheApparition != null && LimiteCoinDroitApparition != null)
        {
            float x = Random.Range(LimiteCoinGaucheApparition.transform.position.x, LimiteCoinDroitApparition.transform.position.x);
            GameObject vie = ObjectPool.Instance.GetPooledObject(ObjetVie);
            if (vie != null)
            {
                vie.transform.position = new Vector2(x, LimiteCoinGaucheApparition.transform.position.y);
                vie.transform.rotation = LimiteCoinGaucheApparition.transform.rotation;
                vie.SetActive(true);
            }
        }
    }
}
