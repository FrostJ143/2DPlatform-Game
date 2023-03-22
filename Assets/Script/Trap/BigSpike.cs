using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpike : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            _animator.SetTrigger("Bouncing");
            player.Bounce(0f, _bounceForce);
            SoundManager.Instance.PlayJumpingSound(transform.position);
        }

    }
}
