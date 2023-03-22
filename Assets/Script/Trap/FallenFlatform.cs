using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenFlatform : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Static;
    }
    
    public void Fall()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
