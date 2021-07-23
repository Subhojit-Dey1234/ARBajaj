using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    private Text scoreText;
    private Animator animator;
    void Awake()
    {
        scoreText = gameObject.GetComponent<Text>();
        animator = gameObject.GetComponentInChildren<Animator>();
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
        animator.SetBool("PlayCoinAnimation",true);
        AudioManager.Instance.PlaySoundOneShot("Point_Audio");
    }
}
