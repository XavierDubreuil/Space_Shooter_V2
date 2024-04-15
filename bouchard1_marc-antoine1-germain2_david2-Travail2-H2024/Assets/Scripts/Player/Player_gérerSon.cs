using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_gérerSon : MonoBehaviour
{

    public static Player_gérerSon Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        /*if (PlayerPrefs.HasKey("sonActivé"))
        {
            AudioSource backgroundSound = GetComponent<AudioSource>();

            if (backgroundSound != null)
            {
                if (PlayerPrefs.GetInt("sonActivé") == 1)
                    backgroundSound.Play();
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SonEstActivé()
    {
        //print("est son");
        //print(PlayerPrefs.HasKey("sonActivé"));

        //print(PlayerPrefs.GetInt("sonActivé"));

        if (PlayerPrefs.HasKey("sonActivé"))
        {
            if (PlayerPrefs.GetInt("sonActivé") == 1)
                return true;          
        }
        return false;
    }
}
