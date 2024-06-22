using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public void endGame (bool win = false) {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            if (!win) Invoke("gameOverScreen", 2);
            else Invoke("winScreen", 2);
        }
    }

    void gameOverScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void winScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    void Update() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) {
            Debug.Log("END END END");
            endGame(true);
        }
    }
}
