using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public static event EventHandler OnCollision;
    
    public static void ResetStaticData()
    {
        OnCollision = null;
    }

    public  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            OnCollision?.Invoke(this, EventArgs.Empty);
        }
    }
}
