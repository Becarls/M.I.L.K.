using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

    public GameObject go_text;
    public GameObject gameover;
    private CanvasRenderer rend;

    void Start() {
        
        rend = gameover.GetComponent<CanvasRenderer>();
        rend.SetAlpha(0f);
    }

	void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            gameover.SetActive(true);
            go_text.SetActive(true);
            for (float i = .01f; i < 1; i += .01f) {
                rend.SetAlpha(i);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
