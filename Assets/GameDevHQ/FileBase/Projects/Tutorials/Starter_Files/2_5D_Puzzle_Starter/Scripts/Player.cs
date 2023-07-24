using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;

    private Vector3 _direction, _velocity
        ;
    private bool _canWallJump;
    private Vector3 _surfaceNormal;
    [SerializeField]
    private float _wallJumpHeight;

    private float _pushPower = 2.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");


        if (_controller.isGrounded == true)
        {
            _canWallJump = false;
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true && _canWallJump == false)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
                else
                {
                    _yVelocity = _wallJumpHeight;
                    _velocity = _surfaceNormal * _speed;
                }

            }
            _yVelocity -= _gravity;
        }
        _velocity.y = _yVelocity;
        Physics.SyncTransforms();
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public int CointCount()
    {
        return _coins;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag =="MovingBox")
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (rb !=null)
            {
                Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);

                rb.velocity = pushDirection * _pushPower;
            }
        }
       

        if (hit.transform.tag == "Wall" && _controller.isGrounded == false)
        {
            _canWallJump = true;
            _surfaceNormal = hit.normal;
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
        }
    }
}
