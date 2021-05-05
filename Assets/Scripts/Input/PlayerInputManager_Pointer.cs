//Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager_Pointer : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;

    [SerializeField] private bool runCoroutineIfNotFound = false;

    public void Awake() {
      PlayerInputManager[] components = GameObject.FindObjectsOfType<PlayerInputManager>();
      if (components.Length >= 1)
        playerInputManager = components[0];
      else if (runCoroutineIfNotFound)
        StartCoroutine("waitForObjectToSpawn");
    }

    public PlayerInputManager getPlayerInputManager(){
      return playerInputManager;
    }

    public IEnumerator waitForObjectToSpawn() {
        int i = 1;
        PlayerInputManager[] components;
        do {
            components = GameObject.FindObjectsOfType<PlayerInputManager>();
            yield return null;
        } while (i != components.Length);

        playerInputManager = components[0];

        yield return null;
    }

    public Vector2 getMoveDirection(){
      return playerInputManager.getMoveDirection();
    }
}
