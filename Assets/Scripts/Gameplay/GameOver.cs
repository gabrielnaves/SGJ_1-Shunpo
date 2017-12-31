using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverText;

    bool gameEnded;

    void Update() {
        if (!gameEnded) {
            if (Katarina.instance.GetComponent<HitPoints>().Died())
                gameEnded = true;
        }
        else {
            gameOverText.SetActive(true);
            if (GameInput.GetAxisDown(InputAxes.jump)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
