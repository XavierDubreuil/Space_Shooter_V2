using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// La classe ObjectPool permet d'utiliser des objets préinstantiés sans les détruire par la suite (ce qui permet de les réutiliser).
/// </summary>
public class ObjectPool : MonoBehaviour
{
    List<GameObject> Pools = new List<GameObject>(); //Les objets à utiliser pour l'ObjectPool.

    [SerializeField] GameObject[] ObjetsPool; //Contient les prefabs utilisés pour instancier tous les objets utilisés pour l'ObjectPool.
    [SerializeField] int[] nombreAPool; //Donne le nombre d'objet à instancier par prefab.

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
                CréerObjet(ObjetsPool[i], ObjetsPool[i].name);
            }
        }
    }

    /// <summary>
    /// La méthode CréerObjet() permet de créer un objet en fonction d'un GameObject donné et en lui donnant un name en particulier.
    /// </summary>
    /// <param name="objetPool">Le prefab a instantié</param>
    /// <param name="nameObjet">Le nom a donné à la propriété name de l'objet créé</param>
    /// <returns></returns>
    private GameObject CréerObjet(GameObject objetPool, string nameObjet)
    {
        GameObject objet = Instantiate(objetPool);
        objet.name = nameObjet;
        objet.SetActive(false);
        Pools.Add(objet);
        return objet;
    }

    /// <summary>
    /// La méthode GetPooledObject() permet de retourner un objet selon le nom de l'objet passé en paramètre.
    /// </summary>
    /// <param name="typeObjet">Le GameObjet a trouvé dans la liste d'objets du ObjectPool.</param>
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
            return CréerObjet(typeObjet, typeObjet.name);
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
