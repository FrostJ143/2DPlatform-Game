using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button _musicBtn;
    [SerializeField] private Button _resumeBtn;
    [SerializeField] private Button _menuBtn;
    [SerializeField] private TextMeshProUGUI _musicVolumeText;
    

    
    private void Awake()
    {
        _musicBtn.onClick.AddListener(() => {
                BGMManager.Instance.ChangeVolume();
                UpdateVisual();
        });
        
        _resumeBtn.onClick.AddListener(() => {
                GameManager.Instance.TooglePauseGame();
        });
        
        _menuBtn.onClick.AddListener(() => {
            Loader.LoadScene(Loader.Scene.StartMenu);
        });
    }
    
    private void Start()
    {
        GameManager.Instance.OnPauseGame += GameManager_OnPauseGame;
        GameManager.Instance.OnUnpauseGame += GameManager_OnUnpauseGame;
        
        UpdateVisual();
        
        Hide();
    }
    
    private void GameManager_OnPauseGame(object sender, System.EventArgs e)
    {
        Show();
    }
    
    private void GameManager_OnUnpauseGame(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        _musicVolumeText.text = "Music: " + BGMManager.Instance.GetVolume().ToString();
    }
    
    private void Show()
    {
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
