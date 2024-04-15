using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// La classe ObjectPool permet d'utiliser des objets pr�instanti�s sans les d�truire par la suite (ce qui permet de les r�utiliser).
/// </summary>
public class ObjectPool : MonoBehaviour
{
    List<GameObject> Pools = new List<GameObject>(); //Les objets � utiliser pour l'ObjectPool.

    [SerializeField] GameObject[] ObjetsPool; //Contient les prefabs utilis�s pour instancier tous les objets utilis�s pour l'ObjectPool.
    [SerializeField] int[] nombreAPool; //Donne le nombre d'objet � instancier par prefab.

    public static ObjectPool Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    void Start()
    {
        //Permet d'instancier tous les objets qu'on va utiliser pour l'ObjectPool.
        for (int i = 0; i < Mathf.Min(ObjetsPool.Length, nombreAPool.Length); i++)
        {
            for (int j = 0; j < nombreAPool[i]; j++)
            {
                Cr�erObjet(ObjetsPool[i], ObjetsPool[i].name);
            }
        }
    }

    /// <summary>
    /// La m�thode Cr�erObjet() permet de cr�er un objet en fonction d'un GameObject donn� et en lui donnant un name en particulier.
    /// </summary>
    /// <param name="objetPool">Le prefab a instanti�</param>
    /// <param name="nameObjet">Le nom a donn� � la propri�t� name de l'objet cr��</param>
    /// <returns></returns>
    private GameObject Cr�erObjet(GameObject objetPool, string nameObjet)
    {
        GameObject objet = Instantiate(objetPool);
        objet.name = nameObjet;
        objet.SetActive(false);
        Pools.Add(objet);
        return objet;
    }

    /// <summary>
    /// La m�thode GetPooledObject() permet de retourner un objet selon le nom de l'objet pass� en param�tre.
    /// </summary>
    /// <param name="typeObjet">Le GameObjet a trouv� dans la liste d'objets du ObjectPool.</param>
    /// <returns></returns>
    public GameObject GetPooledObject(GameObject typeObjet)
    {
        for (int i = 0; i < Pools.Count; i++)
        {
            if (!Pools[i].activeInHierarchy && typeObjet.name == Pools[i].name)
            {
                return Pools[i];
            }
        }
        if (ObjetsPool.Contains(typeObjet))
            return Cr�erObjet(typeObjet, typeObjet.name);
        return null;
    }
    public bool AllEnnemisDisponible()
    {
        for (int i = 0; i < Pools.Count; i++)
        {
            if (Pools[i].activeInHierarchy && Pools[i].name.Contains("Ennemi"))
            {
                return false;
            }
        }
        return true;
    }
}
