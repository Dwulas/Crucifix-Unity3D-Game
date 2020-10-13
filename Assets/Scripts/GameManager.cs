using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource DefaultMusic;
    bool gameHasEnded = false;
    public GameObject Player;
    public Text HowToMove;

    private void Update()
    {
        if (Input.anyKey)
        {
            HowToMove.gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Player.SetActive(false);
            Time.timeScale = .3f;
            Invoke("Restart", 1f);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
