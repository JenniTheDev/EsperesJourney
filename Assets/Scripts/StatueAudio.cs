using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAudio : MonoBehaviour {
    [SerializeField] private AudioSource statueAudio;
    [SerializeField] private List<AudioClip> statuePlaylist;


    public void OnTriggerEnter2D(Collider2D collision) {
        //for (int i = 0; i < statuePlaylist.Count; i++) {
        //    statuePlaylist[i].Play();

        //    // yield return new WaitForSeconds(statuePlaylist[i].clip.length);
        //}
        StartCoroutine(PlayAudioPlaylist());
    }

    private IEnumerator PlayAudioPlaylist() {
        for (int i = 0; i < statuePlaylist.Count; i++) {
            statueAudio.clip = statuePlaylist[i];
            statueAudio.Play();

            yield return new WaitForSeconds(statuePlaylist[i].length);
        }
    }
}