using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private float scoreValue;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        EventManager.UpdateScoreEvent += UpdateScoreText;
        EventManager.ClearScoreEvent += ClearScoreText;
    }

    private void UpdateScoreText()
    {
        scoreValue += 1;
        scoreText.text = scoreValue.ToString();
    }

    private void ClearScoreText()
    {
        scoreValue = 0;
        scoreText.text = scoreValue.ToString();
    }
}
