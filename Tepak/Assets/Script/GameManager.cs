using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject tombolMulai;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    //Play
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        tombolMulai.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Kayu[] kayu = FindObjectsOfType<Kayu>();

        for (int i = 0; i < kayu.Length; i++)
        {
            Destroy(kayu[i].gameObject);
        }
    }

    //Game Over
    public void GameOver()
    {
        tombolMulai.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    //Pause
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    //Score
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
