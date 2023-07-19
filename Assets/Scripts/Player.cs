using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField]
    private float _speed = 3;

    [SerializeField]
    private float _gravity = 1.0f;

    [SerializeField]
    private float _jumpHeight = 15f;
    private float _yVelocity;

    [SerializeField]
    private float _doubleJumpHeight = 8f;
    private bool _isDoubleJump;

    private int _coins;

    private int _lives = 3;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        UIManager.Instance.UPdateLivesText(_lives);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0);
        Vector3 velocity = direction * _speed;
        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _isDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isDoubleJump == true)
                {
                    _yVelocity += _doubleJumpHeight;
                    _isDoubleJump = false;
                }
            }
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        Physics.SyncTransforms();
        _characterController.Move(velocity * Time.deltaTime);
    }

    public void AddCoin()
    {
        _coins += 1;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdatePlayerCoinsConsumed(_coins);
        }
    }

    public void Damage()
    {
        _lives--;
        if (_lives == 0)
        {
            _lives = 0;
            SceneManager.LoadScene(0);
        }
        UIManager.Instance.UPdateLivesText(_lives);
    }
}
