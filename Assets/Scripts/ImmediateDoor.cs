// Vast & Jenni
public class ImmediateDoor : Door {

    protected override void OpenDoor() {
        EventController.Instance.BroadcastDoorOpen();
       // doorAnims.Play("");
        // when animation is over
        
        gameObject.SetActive(false);
    }
}