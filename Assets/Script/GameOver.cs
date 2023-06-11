using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    PlayerControlScript _playerControlScript;

    public TMP_Text Cause;

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
            Cause.text = "(dead by Lack of Food)";
        }
    }
}
