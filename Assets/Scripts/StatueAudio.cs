using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAudio : MonoBehaviour {

    [SerializeField] private List<AudioSource> statuePlaylist;
    private int secondsBetweenSounds;


    public void OnTriggerEnter2D(Collider2D collision) {
        //for (int i = 0; i < statuePlaylist.Count; i++) {
        //    statuePlaylist[i].Play();

        //    // yield return new WaitForSeconds(statuePlaylist[i].clip.length);
        //}
        StartCoroutine(PlayAudioPlaylist());

    }

    IEnumerator PlayAudioPlaylist() {
        for (int i = 0; i < statuePlaylist.Count; i++) {
            statuePlaylist[i].Play();

             yield return new WaitForSeconds(statuePlaylist[i].clip.length);
        }
    }

}
