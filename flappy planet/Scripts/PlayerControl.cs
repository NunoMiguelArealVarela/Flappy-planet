using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int indicesprite;

    public float forca = 5f;
    public float gravidade = -9.81f;
    public float tilt = 5f;

    private Vector3 direcao;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); //vai invocar a funcao AnimateSprite 15 em 15 segundos
    }

    private void OnEnable()
    {
        Vector3 posicao = transform.position;
        posicao.y = 0f;
        transform.position = posicao;
        direcao = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { 
            //entra se carregar ou no espaco ou no botao esquerdo do rato
            direcao = Vector3.up * forca;
        }

        //criar gravidade e atualizar posicao
        direcao.y += gravidade * Time.deltaTime;
        transform.position += direcao * Time.deltaTime;

        //inclinar astraunauta baseado na direcao
        Vector3 rotacao = transform.eulerAngles;
        rotacao.z = direcao.y * tilt;
        transform.eulerAngles = rotacao;
    }

    private void AnimateSprite()
    {
        indicesprite++;

        if (indicesprite >= sprites.Length) {
            indicesprite = 0;
        }

        if (indicesprite < sprites.Length && indicesprite >= 0) {
            spriteRenderer.sprite = sprites[indicesprite];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstaculo")) {
            FindObjectOfType<Parallax>().Reiniciar();
            FindObjectOfType<GameManager>().JogoAcaba();
        } else if (other.gameObject.CompareTag("Passou")) {
            FindObjectOfType<GameManager>().AumentaResultado();
        }
    }

}
