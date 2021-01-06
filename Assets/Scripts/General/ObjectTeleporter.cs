// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleporter : MonoBehaviour
{
    [SerializeField] private Vector3 positionToTeleportTo;
    [SerializeField] private GameObject gameObjectToTeleport;

    // --- Main ------------------------------------

    public void Awake(){
      if(gameObjectToTeleport == null) gameObjectToTeleport = this.gameObject;
    }

    public void teleport(){
      gameObjectToTeleport.transform.position = positionToTeleportTo;
    }

    // --- Get/Set ---------------------------------

    public void setPositionToTeleportTo(Vector3 input){
      positionToTeleportTo = input;
    }

    public void setPositionToTeleportTo(Vector2 input){
      positionToTeleportTo = new Vector3(input.x, input.y, 0);
    }

    public void setPositionToTeleportToCurrentPosition(){
      positionToTeleportTo = gameObjectToTeleport.transform.position;
    }

    public Vector3 getPositionToTeleportTo(){
      return positionToTeleportTo;
    }

    public Vector2 getPositionToTeleportTo_Vector2(){
      Vector2 output = new Vector2(positionToTeleportTo.x, positionToTeleportTo.y);
      return output;
    }

    public void setGameObjectToTeleport(GameObject input){
      gameObjectToTeleport = input;
    }

    public GameObject getGameObjectToTeleportTo(){
      return gameObjectToTeleport;
    }
}
