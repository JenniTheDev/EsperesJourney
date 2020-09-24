// Digx7
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  /* Description --
   *  This script will handel the player inputs using the new input manager package
   *  This is done this way so that the player object can be destroyed and respawned easily
   *  This script was copied from one of my other projects
   */

  public PlayerController playerScript;  // This references the script on the player object we need to access
  public Player Player;                  // This references the input action map
  private GameObject _Player;            // This references the player gameObject in the scene

  public void Awake()
  {
      Player = new Player();             // This is needed to set up the input action map

      Rebind();
  }



  public void Rebind()                   // This script checks if a player is in the scene,  If so it will bind the inputs to the script, If not it will wait unil a player is Instantiated
  {
      // if player gameObject is not set in inspector then it will auto set
      if (_Player == null)
      {
          GameObject[] _player = GameObject.FindGameObjectsWithTag("Player");  // searched for any player gameObject

          int i = 1;
          if (i == _player.Length)
          {
              _Player = _player[0];

              BindInputs();                                    // if one is found it will Bind the needed inputs to the playerScript
          }
          else StartCoroutine("waitForPlayerToSpawn");         // if one is not found it will wait until one is Instantiated
      }
  }


  public void BindInputs ()              // This script will bind the inputs on the Input action map to the needed script
  {
      if (playerScript == null)         // Access the need script on the Player GameObject
      {
          playerScript = _Player.GetComponent<PlayerController>();
      }


      Player.Character.Move.performed += ctx => playerScript.moveDirection = ctx.ReadValue<Vector2>(); // This permantly binds the given inputs to the script with no need for any update function
  }

  public IEnumerator waitForPlayerToSpawn()  // This waits for a player to be Instantiated, when one is it will bind the inputs
  {
      int i = 1;
      GameObject[] _player;
      do
      {
          _player = GameObject.FindGameObjectsWithTag("Player");
          yield return null;
      } while (i != _player.Length);

      _Player = _player[0];

      Rebind();
      BindInputs();

      yield return null;
  }

  private void OnEnable()  // This will enable the Input Action Map
  {
    Player.Enable();
  }

  private void OnDisable() // This will enable the Input Action Map
  {
    Player.Disable();
  }
}
