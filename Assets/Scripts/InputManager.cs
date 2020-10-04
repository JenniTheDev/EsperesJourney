// Bought to you by Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    [SerializeField] private Character character;
    private IMoveableChar playerCharacter;

    #region Monobehavior

    private void Start() {
        playerCharacter = character.GetComponent<IMoveableChar>();
    }

    private void Update() {

        // TODO How do I make the char move only when the key is pressed down? 
        // I tried GetButtonDown but that gives an error on rightKey can't convert to string
        if (Input.GetKey(upKey)) {
            playerCharacter.MoveUp();
        }
        if (Input.GetKey(downKey)) {
            playerCharacter.MoveDown();
        }
        if (Input.GetKey(leftKey)) {
            playerCharacter.MoveLeft();
        }
        if (Input.GetKey(rightKey)) {
            playerCharacter.MoveRight();
        }
        // if (Input.GetButtonDown(rightKey)) {
         //   playerCharacter.MoveRight();
        // }   
    }   

    #endregion
}
