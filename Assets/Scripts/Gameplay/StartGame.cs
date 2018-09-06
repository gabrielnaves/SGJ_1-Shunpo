using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    void Update() {
        if (GameInput.GetAxisDown(InputAxis.Jump) || GameInput.GetAxisDown(InputAxis.DaggerThrow) ||
            GameInput.GetAxisDown(InputAxis.Shunpo) || GameInput.GetAxisDown(InputAxis.SlowMotion) ||
            GameInput.GetAxisDown(InputAxis.Preparation) || GameInput.GetAxisDown(InputAxis.DeathLotus)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
