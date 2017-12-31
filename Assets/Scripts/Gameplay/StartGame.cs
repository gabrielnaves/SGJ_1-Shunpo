using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    void Update() {
        if (GameInput.GetAxisDown(InputAxes.jump) || GameInput.GetAxisDown(InputAxes.daggerThrow) ||
            GameInput.GetAxisDown(InputAxes.shunpo) || GameInput.GetAxisDown(InputAxes.slowMotion) ||
            GameInput.GetAxisDown(InputAxes.preparation) || GameInput.GetAxisDown(InputAxes.deathLotus)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
