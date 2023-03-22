using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}

    public event EventHandler OnJump;
    public event EventHandler OnTogglePause;

    private PlayerInputAction playerInputAction;
    
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInputAction = new PlayerInputAction(); 
        
        playerInputAction.Player.Enable();
        playerInputAction.Player.Jump.performed += Jump_performed;
        playerInputAction.Player.Pause.performed += Pause_performed;
    }
    
    // OnDestroy not Destroy man :((
    private void OnDestroy()
    {
        playerInputAction.Player.Jump.performed -= Jump_performed;
        
        playerInputAction.Dispose();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJump?.Invoke(this, EventArgs.Empty);
    }
    
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTogglePause?.Invoke(this, EventArgs.Empty);
    }
    
    public Vector2 GetMovingDirection()
    {
        Vector2 movingDir = playerInputAction.Player.Move.ReadValue<Vector2>();

        return movingDir;
    }
}
