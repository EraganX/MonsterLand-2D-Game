using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed, _jumpForce;
    [SerializeField] private GameObject _gameoverPanel,_gameInfoPanel;
    
    private float _horizontalInput;

    private bool _isGrounded;
    private bool _isJump;

    private Rigidbody2D _playerRB;
    private Animator _playerAnime;
    private SpriteRenderer _playerSR;

    private HealthBarScript healthBarScript;
    public Image healthbarImage;

    public bool isAttcked;

    void Start()
    {
        _gameoverPanel.SetActive(false);
        _gameInfoPanel.SetActive(true);
        Time.timeScale = 1;

        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnime = GetComponent<Animator>();
        _playerSR = GetComponent<SpriteRenderer>();

        healthBarScript = healthbarImage.GetComponent<HealthBarScript>();
    }

    void Update()
    {
        if (healthBarScript.isHealing==true)
        {
            GetUserInput();
            PlayerAnimation();
        }
        else
        {
            _gameoverPanel.SetActive(true);
            _gameInfoPanel.SetActive(false);
            Time.timeScale = 0;
            isAttcked = false;
            Destroy(gameObject);
            print("Dead - Low health");
        }
        
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
            _gameInfoPanel.SetActive(false);
            Time.timeScale = 0;
            isAttcked = true;
            Destroy(gameObject);
            print("Dead - Enemy Attack");
        }

        if(collision.gameObject.tag == "Food")
        {
            healthBarScript._isEat=true;
            Destroy(collision.gameObject);
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
