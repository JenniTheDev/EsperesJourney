// Vast & Jenni
public class ImmediateDoor : Door {

    protected override void OpenDoor() {
        EventController.Instance.BroadcastDoorOpen();
       
        
        gameObject.SetActive(false);
    }
}