using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI textScore;
    public int score = 0;

    public static Score Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponentInChildren<TextMeshProUGUI>();
        textScore.SetText("Score: "+score);
    }

    public void AugmenterScore()
    {
        score++;
        textScore.SetText("Score: " + score);
    }

    public void AugmenterScoreBoss()
    {
        score += 200;
        textScore.SetText("Score: " + score);
    }
}
