using UnityEngine;
public class Velocidade : MonoBehaviour
{
    public float velocidade = 5f; //velocidade com que os planetas aparecem
    private float ponto_destruicao;
    private void Start() 
    {
        //para saber quando algum objeto passa o limite do ecra e faco isso ao aceder a camera
        ponto_destruicao = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; //ou seja screen space passa a ser o world space ou seja para alem do limite do ecra morre.
        //o inicio do ecra onde vai estar ponto de destruicao vai ser o nosso 0
        //o -1 e para ser uma unidade atras do limite do ecra para dar tempo de ele desaparecer da tela e so apenas depois ser destruido
    }
    private void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime; //os planetas nascem no spawner que e no fim da tela entao eles tem que andar para a esquerda de onde nascem com um velocidade x ao longo do tempo e futuramente vao ser destruidos

        if (transform.position.x < ponto_destruicao) {
            Destroy(gameObject);
        }
    }
}
