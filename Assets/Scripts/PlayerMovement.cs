using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private float moveSpeed = 7f;

    private int _lastMove = 0;

    [SerializeField]
    private float jumpForce = 14f;

    bool _useRawAxis = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = 0f;
        if (_useRawAxis)
        {
            dirX = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            dirX = Input.GetAxis("Horizontal");
        }

        _rb.velocity = new Vector2(dirX * moveSpeed, _rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

        UpdateAnimations(dirX);
    }

    private void UpdateAnimations(float dirX)
    {
        _animator.SetBool("Running", dirX != 0);
        if (dirX == 0)
        {
            _spriteRenderer.flipX = _lastMove == -1;
        }
        if (dirX != 0) 
        { 
            if (_lastMove == -1) 
            {
                _spriteRenderer.flipX = true;
            }
            else if (_lastMove == 1)
            {
                _spriteRenderer.flipX = false;
            }
            _lastMove = dirX < 0 ? -1 : dirX > 0 ? 1 : 0;
        }
    }
}