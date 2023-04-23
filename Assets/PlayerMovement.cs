using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Player;
    bool _useRawAxis = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi");
        Player = GetComponent<Rigidbody2D>();
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

        Player.velocity = new Vector2(dirX * 7f, Player.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Player.velocity = new Vector2(Player.velocity.x, 14f);
        }

    }
}
