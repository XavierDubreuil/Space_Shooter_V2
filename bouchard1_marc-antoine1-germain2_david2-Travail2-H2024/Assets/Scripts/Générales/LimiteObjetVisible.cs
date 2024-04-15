using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe LimiteObjetVisible permet de gérer la désactivation des objets lorsqu'ils ne sont plus visibles sur la caméra du Player (selon des limites).
/// </summary>
public class LimiteObjetVisible : MonoBehaviour
{
    [SerializeField] bool estEnnemi = true;

    GameObject HauteurMaximaleObjet = null;
    GameObject HauteurMinimaleObjet = null;
    void Start()
    {
        //On va chercher les objets qui servent de limites:
        HauteurMaximaleObjet = GameObject.FindGameObjectWithTag("HauteurMaximaleObjet");
        HauteurMinimaleObjet = GameObject.FindGameObjectWithTag("HauteurMinimaleObjet");
    }

    void Update()
    {
        //Permet de gérer la désactivation des objets lorsqu'ils ne sont plus visibles sur la caméra du Player (selon des limites).
        if ((!estEnnemi && this.transform.position.y > HauteurMaximaleObjet.transform.position.y) || this.transform.position.y <= HauteurMinimaleObjet.transform.position.y || this.transform.position.x >= HauteurMaximaleObjet.transform.position.x || this.transform.position.x <= HauteurMinimaleObjet.transform.position.x)
        {
            this.gameObject.SetActive(false);
        }
    }
}
