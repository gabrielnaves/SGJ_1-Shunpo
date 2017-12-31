using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    static public GameOver instance { get; private set; }

    public GameObject gameOverText;
    public float gameTime = 60 * 5; // 5 min

    bool gameEnded;
    float timeSinceEnd;

    void Awake() {
        instance = this;
    }

    void Update() {
        if (!gameEnded) {
            gameTime -= Time.unscaledDeltaTime;
            if (gameTime <= 0) {
                Katarina.instance.GetComponent<Animator>().SetTrigger("died");
                gameTime = 0;
            }
            if (Katarina.instance.GetComponent<HitPoints>().Died() || gameTime <= 0)
                gameEnded = true;
        }
        else {
            timeSinceEnd += Time.unscaledDeltaTime;
            gameOverText.SetActive(true);
            if (GameInput.GetAxisDown(InputAxes.jump) && timeSinceEnd > 0.5f)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
