using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private enum State 
    {
        Idle,
        Moving,
        Jumping,
        Falling,
    }

    private Animator animator;
    private State state;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        Trap.OnCollision += Trap_OnCollision;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
    }
    
    private void Trap_OnCollision(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Die");
    }
    
    private void UpdateAnimations()
    {
        if (animator != null)
        {
            if (player.IsMoving())
            {
                state = State.Moving;
            }
            else 
            {
                state = State.Idle;
            }

            if (player.IsJumping())
            {
                state = State.Jumping;
            }
            else if (player.IsFalling())
            {
                state = State.Falling;
            }
        }

        animator.SetInteger("State", (int)state);

    }
    
    private void RestartLevel()
    {
        Loader.Load();
    }
}
