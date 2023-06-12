using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text _scoreText;
    public GameObject player;

    private PlayerControlScript playerControlScript;
    private int score;

    private void Awake()
    {
        playerControlScript = player.GetComponent<PlayerControlScript>();
        _scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        score = playerControlScript.score;
        _scoreText.text = "coin : " + score.ToString();
    }
}
