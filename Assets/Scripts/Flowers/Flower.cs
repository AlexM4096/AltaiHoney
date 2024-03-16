using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private List<Sprite> flowers = new();
    [SerializeField] private SpriteRenderer  spriteRenderer;
    [SerializeField] private GameObject pestle;
    [SerializeField] private Collider2D _triggerCollider2D;
    [SerializeField] private Collider2D _collider2D;
    public bool FlowerIsActive;
    
    private int _counterSprite = 1;

    private void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        _collider2D = spriteRenderer.GetComponent<Collider2D>();
        _triggerCollider2D = GetComponent<Collider2D>();
        spriteRenderer.sprite = flowers[0];
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == pestle.name)
        {
            if (_counterSprite < flowers.Count) 
            {
                Vector2 spriteSize = spriteRenderer.sprite.bounds.size / 2 ;
                Debug.Log(spriteSize);
                spriteRenderer.sprite = flowers[_counterSprite++]; 
                
                BoxCollider2D boxColliderTrigger = (BoxCollider2D)_triggerCollider2D;
                boxColliderTrigger.size = spriteSize;
                BoxCollider2D boxCollider = (BoxCollider2D)_collider2D;
                boxCollider.size = spriteSize ;

                if (_counterSprite == flowers.Count )
                    FlowerIsActive = true;
            }
        }
    }
}
