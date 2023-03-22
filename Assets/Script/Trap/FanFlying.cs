using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanFlying : MonoBehaviour, IChasingPlayer
{
    [SerializeField] private Player _player;

    private WaypointFollower _waypointFollower;
    
    private float _movingSpeed = 10f;

    private bool _isChasing = false;
    
    private void Awake()
    {
        _waypointFollower = GetComponent<WaypointFollower>();
    }
    
    private void Update()
    {
        if (_isChasing)
        {
            _waypointFollower.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, _player.gameObject.transform.position, _movingSpeed * Time.deltaTime);
        }
    }

    public void SetChasing(bool isChasing)
    {
        _isChasing = isChasing;
    }
}
