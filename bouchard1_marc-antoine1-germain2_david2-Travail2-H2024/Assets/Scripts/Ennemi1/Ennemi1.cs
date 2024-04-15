using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

/// <summary>
/// L'enum Direction va permettre de choisir dans quelle direction, un objet Ennemi1 devrait aller.
/// </summary>
public enum Direction { Bas, Droite, Gauche};
/// <summary>
/// La classe Ennemi1 s'occupe du comportement g�n�ral de l'Ennemi1
/// </summary>
public class Ennemi1 : MonoBehaviour
{
    [SerializeField] float vitesse = 1;
    [SerializeField] Direction sens = Direction.Bas; //Direction de l'Ennemi1
    [SerializeField] bool mouvementEstActiv� = true;
    [SerializeField] bool tourneEstActiv� = true;

    Vector2 direction;
    float rotation;

    bool directionInitialis�e = false;
    bool rotationInitialis�e = false;

    void Start()
    {
        if (!directionInitialis�e)
            InitialiserLaDirection(sens);
        if (!rotationInitialis�e)
            InitialiserLaRotation();
    }

    void Update()
    {
        //Translate en Space World car l'objet doit �tre tourn� pour sa texture (on ne prend pas en compte la rotation de l'objet)
        if (mouvementEstActiv�)
            transform.Translate(direction * vitesse * Time.deltaTime, Space.World);
    }
    /// <summary>
    /// Permet de d�finir la direction vers laquelle l'ennemi se dirige tout en descendant.
    /// </summary>
    /// <param name="direction">Direction voulu (Bas, Droite, Gauche)</param>
    public void InitialiserLaDirection(Direction direction)
    {
        directionInitialis�e = true;

        //Pour la rotation en fonction d'un vecteur:https://www.alloprof.qc.ca/en/students/vl/physics/la-distance-parcourue-et-le-deplacement-p1003 et https://stackoverflow.com/questions/135909/what-is-the-method-for-converting-radians-to-degrees
        switch (direction)
        {
            //Vers le bas
            case Direction.Bas:
                this.direction = new Vector2(0, -1);
                rotation = 0;
                break;
            //L�g�rement vers la droite
            case Direction.Droite:
                this.direction = new Vector2(-0.33f, -0.66f);
                rotation = Mathf.Abs(Mathf.Atan2(this.direction.y, this.direction.x) * (360 / (2 * Mathf.PI))) + 180;
                break;
            //L�g�rement vers la gauche
            case Direction.Gauche:
                this.direction = new Vector2(0.33f, -0.66f);
                rotation = Mathf.Abs(Mathf.Atan2(this.direction.y, this.direction.x) * (360 / (2 * Mathf.PI)));
                break;
        }
    }
    /// <summary>
    /// D�finie la rotation de l'ennemi selon sa direction pour que �a soit joli.
    /// </summary>
    public void InitialiserLaRotation()
    {
        rotationInitialis�e = true;
        if (tourneEstActiv�)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }
    }
    public void setVitesse(float vitesse)
    {
        this.vitesse = vitesse;
    }
}
