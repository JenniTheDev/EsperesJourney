// Digx7
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [Header("Main")]
    [Tooltip("This is where the player will respawn to when the checkpoint is triggered")]
    [SerializeField] private Vector3 checkpointPosition;

    [Tooltip("If toggled on this Check Point Position value will be set to that of this gameObject when the scene starts")]
    [SerializeField] private bool setCheckpointPositionToSelf = true;

    [Tooltip("These are the tags of the gameObjects that this checkpoint is watching for")]
    [SerializeField] private string[] tagsToWatchFor;

    [SerializeField] private enum CheckPointType { SingleUse, InfiniteUse }

    [Tooltip("SingleUse: This checkpoint can only be activated once by the player.   InfiniteUse: This checkpoint will be activated everytime by the player")]
    [SerializeField] private CheckPointType checkPointType;

    [Space]
    [Header("Debuggin")]
    [Tooltip("This is a reference to the player contorller script.  If nothing is there then the player has not interacted with the checkpoint yet")]
    [SerializeField] private PlayerController _PlayerController;

    [Tooltip("This shows weather or not the player has activated this checkpoint before.")]
    [SerializeField] private bool hasBeenUsed = false;

    public void Awake() {
        if (setCheckpointPositionToSelf) checkpointPosition = gameObject.transform.position;
    }

    // --- Tag checking ----------------------------------

    public bool isThisATagToWatchFor(Collision2D col) {
        foreach (string _tag in tagsToWatchFor) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    public bool isThisATagToWatchFor_Trigger(Collider2D col) {
        foreach (string _tag in tagsToWatchFor) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    // --- Main Function ---------------------------------

    public void UpdateCheckPoint() {
        if (!hasBeenUsed || checkPointType == CheckPointType.InfiniteUse)
            _PlayerController.SetPlayerRespawnPosition(checkpointPosition);
    }

    // --- Collision -------------------------------

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.GetComponent<PlayerController>() && isThisATagToWatchFor(col)) {
            _PlayerController = col.gameObject.GetComponent<PlayerController>();
            UpdateCheckPoint();
            hasBeenUsed = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.GetComponent<PlayerController>() && isThisATagToWatchFor_Trigger(col)) {
            _PlayerController = col.gameObject.GetComponent<PlayerController>();
            UpdateCheckPoint();
            hasBeenUsed = true;
        }
    }
}