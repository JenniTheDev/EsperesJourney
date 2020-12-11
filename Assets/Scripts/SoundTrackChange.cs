using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackChange : MonoBehaviour {
    [SerializeField] private AudioSource statueAudio;
    [SerializeField] private List<AudioClip> statuePlaylist;
    private SoundManager audioStuff; 

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            StartCoroutine(PlayAudioPlaylist());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        EventController.Instance.BroadcastOnMusicResume();
        EventController.Instance.BroadcastOnRestartLevelMusic();

        // could also delete game object in case they walk over it
    }

    private IEnumerator PlayAudioPlaylist() {
        for (int i = 0; i < statuePlaylist.Count; i++) {
            statueAudio.clip = statuePlaylist[i];
            statueAudio.Play();

            yield return new WaitForSeconds(statuePlaylist[i].length);
        }
    }
}