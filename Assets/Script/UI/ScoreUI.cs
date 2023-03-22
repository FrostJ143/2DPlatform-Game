using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnCollect += GameManager_OnCollect;
    }
    
    private void GameManager_OnCollect(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        scoreText.text = "Cherries: "  + GameManager.Instance.GetScore().ToString();
    }
}
