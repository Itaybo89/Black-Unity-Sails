using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    [SerializeField] Slider mySlider;
    [SerializeField] Health playerHealth;
    void Start()
    { 
        SliderStats();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        ScoreUpdate();
        SliderUpdater();
    }

    void ScoreUpdate()
    {
        scoreText.text = scoreKeeper.ReturnScore().ToString("000000000");
    }
    
    void SliderStats()
    {
        mySlider.maxValue = playerHealth.GetHealth();
        mySlider.minValue = 0;
    }

    public void SliderUpdater()
    { 
        mySlider.value = playerHealth.GetHealth();
    }
}
