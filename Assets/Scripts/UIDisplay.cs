using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.Gethealth();
    }

    void Update()
    {
       healthSlider.value = playerHealth.Gethealth();
       scoreText.text = scoreKeeper.GetScore().ToString("0000000000");
    }
}
