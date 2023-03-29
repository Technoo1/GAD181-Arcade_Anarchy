using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1.0f;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;

    public void awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start() 
    
    {
     InvokeRepeating(nameof(animationSprites), this.animationTime, this.animationTime);   
    }

    private void AnimateSprite()
    {
        _animationFrame ++;

        if(_animationFrame > this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
        else if(_animationFrame == this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
}
