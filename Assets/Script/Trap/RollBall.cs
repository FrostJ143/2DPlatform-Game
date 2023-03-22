using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBall : Trap, IChasingPlayer
{
    [SerializeField] private Transform _player;
    
    private bool _isChasing = false;
    private float _movingSpeed = 10f;
    private float _rotateSpeed = 2f;

    private void Update()
    {
        if (_isChasing)
        {
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime * 360);
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _movingSpeed * Time.deltaTime);
        }
    }
    
    public void SetChasing(bool isChasing)
    {
        _isChasing = isChasing;
    }
}
