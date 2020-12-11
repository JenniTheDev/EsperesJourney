using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackChange : MonoBehaviour {

    private SoundManager soundsToChange;

    private void OnTriggerEnter2D(Collider2D collision) {
        EventController.Instance.BroadcastOnMusicPause();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        EventController.Instance.BroadcastOnMusicResume();
        // could also delete game object in case they walk over it
        
    }


}
