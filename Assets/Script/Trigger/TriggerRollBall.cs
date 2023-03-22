using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRollBall : MonoBehaviour
{
    [SerializeField] private Transform _object;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            IChasingPlayer chasingObject = _object.GetComponent<IChasingPlayer>();
            chasingObject.SetChasing(true);
        }
    }
}
