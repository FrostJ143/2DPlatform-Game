using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class EndMenuUI : MonoBehaviour
{
    private const string PLAYER_PREFS_TOTAL_PLAY_TIME = "TotalPlayTime";

    [SerializeField] private Button _quitButton;
    [SerializeField] private TextMeshProUGUI _totalPlayTimeText;

    private float _totalPlayTime;

    private void Awake()
    {
        _quitButton.onClick.AddListener(() => {
                Application.Quit();
        });
        
        _totalPlayTime = PlayerPrefs.GetFloat(PLAYER_PREFS_TOTAL_PLAY_TIME, 0f);
        PlayerPrefs.SetFloat(PLAYER_PREFS_TOTAL_PLAY_TIME, 0f);
    }
    
    private void Start()
    {
        UpdateVisual();
    }
    
    private void UpdateVisual()
    {
        int totalMinutes = Mathf.RoundToInt(_totalPlayTime / 60);
        int totalSeconds = Mathf.RoundToInt(_totalPlayTime % 60);
        if (totalMinutes > 0)
        {
            _totalPlayTimeText.text = "Played time: " + totalMinutes.ToString() + "'" + totalSeconds.ToString() + "s";
        }
        else
        {
            _totalPlayTimeText.text = "Played time: " + totalSeconds.ToString() + "s";
        }
    }
}
