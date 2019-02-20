using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // handle to animator
    private Animator _anim;
    private Animator _swordAnim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordSprite;
    
    public float move;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void Move(float move)
    {

        Flip(move);
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        if(_sprite.flipX == true)
        {
            _swordSprite.flipY = true;
        }
        else
        {
            _swordSprite.flipY = false;
        }
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }

    void Flip(float move)
    {
        if (move < 0)
        {
            _sprite.flipX = true;
        }
        else if (move > 0)
        {
            _sprite.flipX = false;
        }
    }
}
