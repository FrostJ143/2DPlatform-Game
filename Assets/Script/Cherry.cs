using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public static event EventHandler OnCollect;
    
    private bool _firstEnter = true;
    
    public static void ResetStaticData()
    {
        OnCollect = null;
    }

    [SerializeField] private ScriptableObject cherrySO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_firstEnter)
        {
            _firstEnter = false;
            DestroySelf();
            OnCollect?.Invoke(this, EventArgs.Empty);
        }
    }


    
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
