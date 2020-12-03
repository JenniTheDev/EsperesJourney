using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeDoor : Door {
    protected override void OpenDoor() {
        EventController.Instance.BroadcastBridgeOpen();
        gameObject.SetActive(false);
    }
}
