using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
/// <summary>
/// La classe Ennemi2 s'occupe du comportement général de l'Ennemi2
/// </summary>
public class Ennemi2 : MonoBehaviour
{
    Vector2 direction = new Vector2(0, 1);
    [SerializeField] float vitesseDesEnnemis = 1f;
    float posHorizontal;
    float posVertical = 0;
    [SerializeField] float amplitude = 3;
    [SerializeField] float période = 3;
    float verticalOrigine;
    float horizontalOrigine;


    [SerializeField] float vitesseApparitionBalle = 3f;
    [SerializeField] GameObject balle = null;

    GameObject player;
    float time = 0;

    private void OnEnable()
    {
        //Variables de départ de la fonc. sinusoidale correspondant aux mouvements de l'ennemi
        horizontalOrigine = transform.position.x;
        verticalOrigine = transform.position.y;
        posVertical = transform.position.y;
        //Recherche du joueur pour la trajectoire des balles
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            direction = new Vector2(0, 1);
    }

    void Update()
    {
        //Déplacement de l'ennemi avec la fonction sinusoidale
        posHorizontal = amplitude * Mathf.Sin(période * (posVertical - verticalOrigine)) + horizontalOrigine;
        transform.position = new Vector2(posHorizontal, posVertical);
        posVertical -= Time.deltaTime * vitesseDesEnnemis;
        //Apparition des balles
        if (time > vitesseApparitionBalle)
        {
            if (player != null)
                direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            GameObject NouvelleBalle = ObjectPool.Instance.GetPooledObject(balle);
            if (NouvelleBalle != null)
            {
                NouvelleBalle.transform.position = transform.position;
                NouvelleBalle.transform.rotation = Quaternion.LookRotation(direction);
                NouvelleBalle.SetActive(true);
            }
            time = 0;
        }
        time += Time.deltaTime;
    }
    public void setVitesse(float vitesse, float delai_balle)
    {
        vitesseDesEnnemis = vitesse;
        vitesseApparitionBalle = delai_balle;
    }
}