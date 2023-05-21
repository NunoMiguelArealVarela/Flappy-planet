using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerControl jogador;
    public Text resultadoTexto;
    public Text highscoreTexto;
    public GameObject gameOver;
    public GameObject playButton;
    public float spawn; 

    private int resultado;

    private void Start()
    {
        highscoreTexto.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore", 0).ToString(); //vai buscar valor de highscore e vai dar print
        //0 serve para dar valor default que so vai ser usado a primeira vez de todas que o jogador nao tem highscore
    }

    private void Awake() //quando jogo comeca quero pausa porque so quer comecar jogo quando carrego botao
    {
        Application.targetFrameRate = 60; //nao obrigatorio mas referir com 60 frame por segundo
        Pausar();
    }

    public void Jogar()
    {
        resultado = 0;
        resultadoTexto.text = resultado.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1;
        jogador.enabled = true;

        //quando clico play quero apagar os prefabs anteriores que estao na tela no instante que eu morri da ultima vez
        Velocidade[] prefabs = FindObjectsOfType<Velocidade>();

        for (int i = 0; i < prefabs.Length; i++) {
            Destroy(prefabs[i].gameObject);
        }
    }

    public void Pausar()
    {
        Time.timeScale = 0f; //definir isto a zero e obrigar o jogador comecar parado porque tudo o que se mexe multiplica por tempo
        jogador.enabled = false;
    }


    public void JogoAcaba()
    {
        //quando ou bate no chao ou bate num pipe
        if (resultado > PlayerPrefs.GetInt("highscore")) //entra aqui se resultado for maior que highscore
        {
            PlayerPrefs.SetInt("highscore", resultado); //vai guardar na key highscore o valor de resultado
            highscoreTexto.text = "HIGHSCORE: " + resultado; //e vai dar print
        }

        gameOver.SetActive(true);
        playButton.SetActive(true);


        Pausar();
    }

    public void AumentaResultado()
    {
        resultado++; //quando passa na score zona entre os planetas
        resultadoTexto.text = resultado.ToString();
    }
}
