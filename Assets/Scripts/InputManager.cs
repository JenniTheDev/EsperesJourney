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

        if (Input.GetKeyDown(upKey)) {
            playerCharacter.MoveUp();
        }
        if (Input.GetKeyDown(downKey)) {
            playerCharacter.MoveDown();
        }
        if (Input.GetKeyDown(leftKey)) {
            playerCharacter.MoveLeft();
        }
        if (Input.GetKeyDown(rightKey)) {
            playerCharacter.MoveRight();
        }

    }

    #endregion
}
