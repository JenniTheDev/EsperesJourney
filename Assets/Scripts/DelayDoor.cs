using System.Collections;
using UnityEngine;

public class DelayDoor : Door {
    private float delay = 0.5f;

    protected override void OpenDoor() {
        StartCoroutine(WaitASecond());
       
    }

    private IEnumerator WaitASecond() {
        yield return new WaitForSecondsRealtime(delay);
        EventController.Instance.BroadcastDoorOpen();
        gameObject.SetActive(false);
    }
}