using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    [SerializeField] private float rotateSpeed = 2f;

    private void Update()
    {
        transform.Rotate(0, 0, 360 * rotateSpeed * Time.deltaTime);
    }
}
