using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    
    private void Awake()
    {
        _playButton.onClick.AddListener(() => {
                Loader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
        });
        
        _quitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }
}
