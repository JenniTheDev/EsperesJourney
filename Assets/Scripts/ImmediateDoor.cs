public class ImmediateDoor : Door {
    protected override void OpenDoor() {
        gameObject.SetActive(false);
    }
}