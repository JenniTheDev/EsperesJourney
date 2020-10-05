// Bought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // These can be removed as this is built in to use WASD
    // [SerializeField] private KeyCode upKey = KeyCode.W;
    // [SerializeField] private KeyCode downKey = KeyCode.S;
    // [SerializeField] private KeyCode leftKey = KeyCode.A;
    // [SerializeField] private KeyCode rightKey = KeyCode.D;

    [SerializeField] private KeyCode pauseButton = KeyCode.P;
    [SerializeField] private KeyCode resumeButton = KeyCode.P;
    [SerializeField] private KeyCode exitGame;

    [SerializeField] private Character character;
    private IMoveableChar playerCharacter;
    private float vinput = 0.0f;
    private float hinput = 0.0f;
    #region Monobehavior

    private void Start() {
        playerCharacter = character.GetComponent<IMoveableChar>();
    }

    private void Update() {

        // moves character any direction by getting x & y
        vinput = Input.GetAxis("Vertical");
        hinput = Input.GetAxis("Horizontal");

        if (vinput != 0.0f || hinput != 0.0f) {
            playerCharacter.Move(new Vector2(hinput, vinput));
        }
        // if (Input.GetButtonDown(rightKey)) {
         //   playerCharacter.MoveRight();
        // }   
    }   

    }

    #endregion
}
