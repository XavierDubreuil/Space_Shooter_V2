using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

/// <summary>
/// L'enum Direction va permettre de choisir dans quelle direction, un objet Ennemi1 devrait aller.
/// </summary>
public enum Direction { Bas, Droite, Gauche};
/// <summary>
/// La classe Ennemi1 s'occupe du comportement général de l'Ennemi1
/// </summary>
public class Ennemi1 : MonoBehaviour
{
    [SerializeField] float vitesse = 1;
    [SerializeField] Direction sens = Direction.Bas; //Direction de l'Ennemi1
    [SerializeField] bool mouvementEstActivé = true;
    [SerializeField] bool tourneEstActivé = true;

    Vector2 direction;
    float rotation;

    bool directionInitialisée = false;
    bool rotationInitialisée = false;

    void Start()
    {
        if (!directionInitialisée)
            InitialiserLaDirection(sens);
        if (!rotationInitialisée)
            InitialiserLaRotation();
    }

    void Update()
    {
        //Translate en Space World car l'objet doit être tourné pour sa texture (on ne prend pas en compte la rotation de l'objet)
        if (mouvementEstActivé)
            transform.Translate(direction * vitesse * Time.deltaTime, Space.World);
    }
    /// <summary>
    /// Permet de définir la direction vers laquelle l'ennemi se dirige tout en descendant.
    /// </summary>
    /// <param name="direction">Direction voulu (Bas, Droite, Gauche)</param>
    public void InitialiserLaDirection(Direction direction)
    {
        directionInitialisée = true;

        //Pour la rotation en fonction d'un vecteur:https://www.alloprof.qc.ca/en/students/vl/physics/la-distance-parcourue-et-le-deplacement-p1003 et https://stackoverflow.com/questions/135909/what-is-the-method-for-converting-radians-to-degrees
        switch (direction)
        {
            //Vers le bas
            case Direction.Bas:
                this.direction = new Vector2(0, -1);
                rotation = 0;
                break;
            //Légèrement vers la droite
            case Direction.Droite:
                this.direction = new Vector2(-0.33f, -0.66f);
                rotation = Mathf.Abs(Mathf.Atan2(this.direction.y, this.direction.x) * (360 / (2 * Mathf.PI))) + 180;
                break;
            //Légèrement vers la gauche
            case Direction.Gauche:
                this.direction = new Vector2(0.33f, -0.66f);
                rotation = Mathf.Abs(Mathf.Atan2(this.direction.y, this.direction.x) * (360 / (2 * Mathf.PI)));
                break;
        }
    }
    /// <summary>
    /// Définie la rotation de l'ennemi selon sa direction pour que ça soit joli.
    /// </summary>
    public void InitialiserLaRotation()
    {
        rotationInitialisée = true;
        if (tourneEstActivé)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }
    }
    public void setVitesse(float vitesse)
    {
        this.vitesse = vitesse;
    }
}
