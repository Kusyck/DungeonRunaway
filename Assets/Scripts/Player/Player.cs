using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float _speed = 2.5f;
    private PlayerAnimation _anim;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        
        _body.velocity = new Vector2(move * _speed, _body.velocity.y);
        _anim.Move(move);
        Jump();
    }

    void Jump()
    {
        //Raycast is hitting only in layer 8 = "Ground"
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null)
        {
            _anim.Jump(true);
            Debug.Log("Jump on: " + hit.collider.name);
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
        }
        else
        {
            _anim.Jump(false);
        }
    }
    void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        if(Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
        {
            _anim.Attack();
        }
    }
}
