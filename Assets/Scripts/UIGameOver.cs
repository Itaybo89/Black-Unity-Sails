using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        ScoreUpdate();
    } 
    

     void ScoreUpdate()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.ReturnScore().ToString("000000000");
    }


}
