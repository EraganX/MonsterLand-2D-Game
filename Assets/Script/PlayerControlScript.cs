using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed, _jumpForce;
    [SerializeField] private GameObject _gameoverPanel;
    
    private float _horizontalInput;

    private bool _isGrounded;
    private bool _isJump;

    private Rigidbody2D _playerRB;
    private Animator _playerAnime;
    private SpriteRenderer _playerSR;

    void Start()
    {
        _gameoverPanel.SetActive(false);
        Time.timeScale = 1;

        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnime = GetComponent<Animator>();
        _playerSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetUserInput();
        PlayerAnimation();
    }

    private void GetUserInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(_horizontalInput, 0f, 0f) * _moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJump = true;
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            _isGrounded = true;
            _isJump = false;
        }

        if (collision.gameObject.CompareTag("Enemie"))
        {
            _gameoverPanel.SetActive(true);

            Time.timeScale = 0;

            Destroy(gameObject);
        }
    }

    private void PlayerAnimation() {
        if (_horizontalInput > 0) {
            _playerSR.flipX = false;
            _playerAnime.SetBool("run",true);
        }
        else if (_horizontalInput < 0) {
            _playerSR.flipX = true;
            _playerAnime.SetBool("run", true);
        }
        else {
            _playerAnime.SetBool("run", false);
        }


        if (_isJump)
        {
            _playerAnime.SetBool("jump", true);
        }
        else {
            _playerAnime.SetBool("jump", false);
        }

        
    }
}
