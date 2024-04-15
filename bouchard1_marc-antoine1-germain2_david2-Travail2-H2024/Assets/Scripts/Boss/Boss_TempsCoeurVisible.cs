using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_TempsCoeurVisible : MonoBehaviour
{
    [SerializeField] GameObject Cible1;
    [SerializeField] GameObject Cible2;
    [SerializeField] float tempsVisible = 3f;
    float tempsÉcoulé = 0f;

    Boss_Cible Boss_Cible_Cible1;
    Boss_Cible Boss_Cible_Cible2;

    /* CircleCollider2D CircleCollider_Cible1;
     CircleCollider2D CircleCollider_Cible2;*/


    // Start is called before the first frame update
    void Start()
    {
        if (Cible1 != null)
            Boss_Cible_Cible1 = Cible1.GetComponent<Boss_Cible>();
        if (Cible2 != null)
            Boss_Cible_Cible2 = Cible2.GetComponent<Boss_Cible>();
        /*
        if (Cible1 != null)
            CircleCollider_Cible1 = Cible1.GetComponent<CircleCollider2D>();
        if (Cible2 != null)
            CircleCollider_Cible2 = Cible2.GetComponent<CircleCollider2D>();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (tempsÉcoulé >= tempsVisible)
        {
            gameObject.SetActive(false);
            if (Boss_Cible_Cible1 != null)
            {
                Boss_Cible_Cible1.ActiverCible();
            }
            if (Boss_Cible_Cible2 != null)
            {
                Boss_Cible_Cible2.ActiverCible();
            }
            tempsÉcoulé = 0f;
        }
        tempsÉcoulé += Time.deltaTime;
    }

    public void RéinitialiserValeur()
    {
        tempsÉcoulé = 0f;
    }
}
