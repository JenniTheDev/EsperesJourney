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
    }

    #endregion
}
