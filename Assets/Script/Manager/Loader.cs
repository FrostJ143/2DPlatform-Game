using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    
    public enum Scene 
    {
        StartMenu,
        Level1,
        Level2,
        EndMenu,
    }
    public static void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public static void LoadNextLevel(int currentIndex)
    {
        SceneManager.LoadScene(currentIndex + 1);
    }
    
    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
