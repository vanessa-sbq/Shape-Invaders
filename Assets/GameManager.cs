using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public void endGame () {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("gameOverScreen", 2);
        }
    }

    void gameOverScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
