using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpitOut : MonoBehaviour
{
    [SerializeField] private Transform _object1;
    [SerializeField] private Transform _object2;
    [SerializeField] private Vector3 _object1Position;
    [SerializeField] private Vector3 _object2Position;
    
    private bool _isSplitOut = false;
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.GetComponent<Player>())
        {
            if (!_isSplitOut)
            {
                _isSplitOut = true;
                _object1.position = _object1Position;
                _object2.position = _object2Position;
            }
        }
    }
    
}
