using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    PlayerControlScript _playerControlScript;

    public TMP_Text Cause;
    public TMP_Text Score;

    private void Awake()
    {
        _playerControlScript = _player.GetComponent<PlayerControlScript>();
    }
    private void Update()
    {
        if (_playerControlScript.isAttcked)
        {
            Cause.text = "(Attcked by Monster)";
        }
        else
        {
            Cause.text = "(Low health)";
        }

        Score.text = "Score : " + _playerControlScript.score.ToString();
    }
}
