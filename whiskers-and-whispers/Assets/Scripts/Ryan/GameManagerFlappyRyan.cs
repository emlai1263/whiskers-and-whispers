using System.IO.Pipes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerRyan : MonoBehaviour
{
    public PlayerRyan player;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject playButton2;
    public GameObject gameOver;
    [SerializeField] GameObject creditText;
    public GameObject gameEnd;
    private int score;

    public void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
        creditText.SetActive(false);
        gameEnd.SetActive(false);
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        creditText.SetActive(false);
        gameEnd.SetActive(false);
        playButton2.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Meteors[] meteors = FindObjectsOfType<Meteors>();

        for (int i = 0; i < meteors.Length; i++)
        {
            Destroy(meteors[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score == 2)
        {
            GameEnd();
        }
    }

    public void GameEnd()
    {
        // Time.timeScale = 0f;
        // player.enabled = false;

        // gameEnd.SetActive(true);
        // creditText.SetActive(true);
        // playButton2.SetActive(true);
        SceneManager.LoadScene("AfterFlappyRyan");

    }
}
