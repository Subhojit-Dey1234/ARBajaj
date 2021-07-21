using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    private Text scoreText;
    void Awake()
    {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = "0";
    }

    private void OnEnable()
    {
        EnemyDestroyManager.OnEnemyDestroyed += UpdateScoreOnEnemyDestroyed;
    }
    private void OnDisable()
    {
        EnemyDestroyManager.OnEnemyDestroyed -= UpdateScoreOnEnemyDestroyed;
    }

    private void UpdateScoreOnEnemyDestroyed(int pointsOnSingleHit)
    {
        scoreText.text = (Int32.Parse(scoreText.text) + pointsOnSingleHit).ToString();
    }
}
