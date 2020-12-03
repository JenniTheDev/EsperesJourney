using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}