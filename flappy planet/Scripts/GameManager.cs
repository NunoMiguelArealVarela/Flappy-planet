using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    private Spawner spawner;
    private Pipes planets;

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public Text scoreText;
    public Text hiscoreText;

    public GameObject play;
    public GameObject gameOver;
    public float score { get; private set; }


    private void Start(){
        
        
    }

    private void Awake()
    {
    
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        planets = FindObjectOfType<Pipes>();
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        play.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        play.SetActive(true);
        gameOver.SetActive(true);

        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = "HI: "+ Mathf.FloorToInt(hiscore).ToString();
        Pause();
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }


    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();
        
    }

}
