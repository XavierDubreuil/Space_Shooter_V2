using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFin : MonoBehaviour
{
    [SerializeField] AudioSource sonResultat;
    // Start is called before the first frame update
    /// <summary>
    /// Elle a pour seul effet d'activer le son de fin en mode r�p�tition
    /// </summary>
    void Start()
    {
        if (PlayerPrefs.HasKey("sonActiv�"))
        {
            if (PlayerPrefs.GetInt("sonActiv�") == 1)
                sonResultat.Play();
        }
    }
}
