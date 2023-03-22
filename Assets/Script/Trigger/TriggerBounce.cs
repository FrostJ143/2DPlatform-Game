using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBounce : MonoBehaviour
{
    [SerializeField] private float bounceForceY = 20f;
    [SerializeField] private float bounceForceX = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player =  collision.gameObject.GetComponent<Player>();
            player.Bounce(bounceForceX, bounceForceY);
        }
    }
}
