using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    
    private const string PLAYER_PREFS_TOTAL_PLAY_TIME = "TotalPlayTime";
    public event EventHandler OnCollect;
    public event EventHandler OnPauseGame;
    public event EventHandler OnUnpauseGame;

    private int cherriesCount;
    private bool _isPauseGame = false;
    private System.DateTime startTime;
    private double _totalPlayTime;

    
    
    private void Awake()
    {
        Instance = this;
        
        _totalPlayTime = (double)PlayerPrefs.GetFloat("TotalPlayTime", 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        GameInput.Instance.OnTogglePause += GameInput_OnTogglePauseGame;
        Cherry.OnCollect += Cherry_OnCollect;
        Trap.OnCollision += Trap_OnCollision;
    }
    
    private void Cherry_OnCollect(object sender, System.EventArgs e)
    {
        ++cherriesCount;
        OnCollect?.Invoke(this, EventArgs.Empty);
    }
    
    private void Trap_OnCollision(object sender, System.EventArgs e)
    {
        SetTotalPlayTime();
    }
    
    private void GameInput_OnTogglePauseGame(object sender, System.EventArgs e)
    {
        TooglePauseGame();
    }

    public int GetScore()
    {
        return cherriesCount;
    }
    
    public void TooglePauseGame()
    {
        if (!_isPauseGame)
        {
            Time.timeScale = 0f;
            _isPauseGame = true;
            OnPauseGame?.Invoke(this, EventArgs.Empty);
        }
        else 
        {
            Time.timeScale = 1f;
            _isPauseGame = false;
            OnUnpauseGame?.Invoke(this, EventArgs.Empty);
        }

    }
    
    public float GetTotalPlayTime()
    {
        return (float)_totalPlayTime;
    }
    
    public void SetTotalPlayTime()
    {
        double timeDiff = (DateTime.Now - startTime).TotalSeconds;
        _totalPlayTime += timeDiff;
        PlayerPrefs.SetFloat(PLAYER_PREFS_TOTAL_PLAY_TIME, (float)_totalPlayTime);
    }
}
