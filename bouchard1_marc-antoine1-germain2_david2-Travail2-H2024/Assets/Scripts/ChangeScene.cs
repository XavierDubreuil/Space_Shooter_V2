using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// La classe MoveToScene() s'occupe du changement de quelques scènes.
/// </summary>
public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID); //s'occupe de changer de scène
    }
}
