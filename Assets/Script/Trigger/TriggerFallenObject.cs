using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallenObject : MonoBehaviour
{
    [SerializeField] private Transform _fallenObject;
    
    private bool _isSpawn = false;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_isSpawn)
        {
            _isSpawn = true;
            Vector3 position = new Vector3(46.5f, 10f, 0f);
            Transform fallenObjectTransform = Instantiate(_fallenObject);
            fallenObjectTransform.position = position;
        }
    }
}
