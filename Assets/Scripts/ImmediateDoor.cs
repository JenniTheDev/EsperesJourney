// Vast & Jenni
public class ImmediateDoor : Door {

    protected override void OpenDoor() {
        // No noise door right now
        //  EventController.Instance.BroadcastDoorOpen();

        gameObject.SetActive(false);
    }
}