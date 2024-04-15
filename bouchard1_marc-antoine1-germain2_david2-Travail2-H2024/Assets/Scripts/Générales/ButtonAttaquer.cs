using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAttaquer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Player_Tirer player_Tirer;
    bool estTouché = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (estTouché)
        {
            if (player_Tirer != null)
            {
                player_Tirer.TirerMobile();
            }
        }
    }

    //https://forum.unity.com/threads/long-press-gesture-on-ugui-button.264388/ (OnPointerDown et OnPointerUp):
    public void OnPointerDown(PointerEventData eventData)
    {
        estTouché = true;
        print("Boutton attaquer:"+estTouché);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        estTouché = false;
        print("Boutton attaquer:" + estTouché);        
    }
}
