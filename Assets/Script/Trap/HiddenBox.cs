using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBox : MonoBehaviour
{
    private SpriteRenderer sprite;
    private PlatformEffector2D platformEffector;
    
    private void Awake()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
        sprite = GetComponent<SpriteRenderer>(); 
    }
    
    private void Start()
    {
        sprite.enabled = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player && collision.contacts[0].normal.y > 0.5f) 
        {
            platformEffector.surfaceArc = 360;
            sprite.enabled = true;
            player.Bounce(0f, -10f);
        }
    }
}
