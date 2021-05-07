// Digx7
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerTestSceneCode : MonoBehaviour {
    // THIS CODE WAS BUILT FOR THE SPECIFIC DEV SCENE "PLAYER CONTROLLER" AND IS
    // NOT MEANT TO BE USED IN THE FINAL PRODUCT

    // This code shows what needs to happen for the player to respawn
    // 1. a new player prefab needs to be Instantiated
    // 2. the PlayerInput.Rebind() function needs to be run in order to bind the inputs to the new player prefab

    public Spawner playerSpawner;
    public PlayerInput codeHolder;

    public UnityEvent FKeyPressed;
    public UnityEvent IKeyPressed;
    public UnityEvent AKeyPressed;
    public UnityEvent DKeyPressed;
    public UnityEvent RKeyPressed;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.F)) FKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.I)) IKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.A)) AKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.D)) DKeyPressed.Invoke();
        if (Input.GetKeyDown(KeyCode.R)) RKeyPressed.Invoke();
    }

    public void OnStartEventIdle() {
        Debug.Log("The 'On Start' event in the 'Idle' state has been called");
    }

    public void OnEndStateIdle() {
        Debug.Log("The 'On End' event in the 'Idle' state has been called");
    }

    public void OnStartEventFollow() {
        Debug.Log("The 'On Start' event in the 'Follow' state has been called");
    }

    public void OnEndEventFollow() {
        Debug.Log("The 'On End' event in the 'Follow' state has been called");
    }

    public void OnStartEventAttack() {
        Debug.Log("The 'On Start' event in the 'Attack' state has been called");
    }

    public void OnEndEventAttack() {
        Debug.Log("The 'On End' event in the 'Attack' state has been called");
    }

    public void OnStartEventDie() {
        Debug.Log("The 'On Start' event in the 'Die' state has been called");
    }

    public void OnEndEventDie() {
        Debug.Log("The 'On End' event in the 'Die' state has been called");
    }
}