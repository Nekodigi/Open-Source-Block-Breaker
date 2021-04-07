using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMain : MonoBehaviour
{
    public static Text text;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addScore(int pt)
    {
        score += pt;
        text.text = "Score " + score;
    }

    public static void setScore(int score_)
    {
        score = score_;
        text.text = "Score " + score;
    }
}
