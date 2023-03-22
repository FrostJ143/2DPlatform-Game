using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set;}

    public float sfxVolume = 1f;

    [SerializeField] private SoundEffectsListSO sfxList;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        Cherry.OnCollect += Cherry_OnCollect;
        // Trap.OnCollision += Trap_OnCollision;
    }
    
    private void Cherry_OnCollect(object sender, System.EventArgs e)
    {
        Cherry cherry = sender as Cherry;
        PlaySound(sfxList.collect, cherry.transform.position);
    }
    
    // private void Trap_OnCollision(object sender, System.EventArgs e)
    // {
    //     Trap trap = sender as Trap;
    //     PlaySound(sfxList.die, trap.transform.position);
    // }
    
    public void PlayDieSound(Vector3 position)
    {
        PlaySound(sfxList.die, position);
    }
    
    public void PlayJumpingSound(Vector3 position)
    {
        PlaySound(sfxList.jumping, position);
    }
    
    public void PlayFinishSound(Vector3 position)
    {
        PlaySound(sfxList.finish, position);
    }
    
    public void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, 1);
    }
}
