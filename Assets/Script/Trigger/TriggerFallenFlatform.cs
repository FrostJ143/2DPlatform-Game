using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallenFlatform : MonoBehaviour
{
    [SerializeField] private FallenFlatform _fallenFlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _fallenFlatform.Fall();
        }
    }
}
