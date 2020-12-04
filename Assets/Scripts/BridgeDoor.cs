// Jenni
public class BridgeDoor : Door {
    protected override void OpenDoor() {
        EventController.Instance.BroadcastBridgeOpen();
        gameObject.SetActive(false);
    }
}
