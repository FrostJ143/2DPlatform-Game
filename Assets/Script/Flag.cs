using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private bool firstTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!firstTrigger)
        {
            SoundManager.Instance.PlayFinishSound(transform.position);
            GameManager.Instance.SetTotalPlayTime();
            Invoke("CallBack", 1f);
        }
    }
    
    private void CallBack()
    {
            Loader.LoadScene(Loader.Scene.EndMenu);
    }
}
