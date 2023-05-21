using UnityEngine;
public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float velocidadecenario = 1f;
    private void Awake()
    {
      meshRenderer = GetComponent<MeshRenderer>(); //antes do jogo comecar, vai onde as texturas do cenario estao e guarda em meshRanderer
    }
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(velocidadecenario * Time.deltaTime, 0); //somar para ir aumentando velocidade ao longo do tempo e so tem component x porque y nao interessa para o correr do cenario
    }
}
