using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Letras : MonoBehaviour //FUNCIONA APENAS COM CAMERA ORTOGRAFICAS
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    Rigidbody2D _rigidbody2D;
    float distancia;

    [HideInInspector]//deixa publica mas nao aparece no inspectro 
    public bool estaConectado;
    
    [Range(1,15)]//limitar o valor que a variavel pode obter
    public float velocidadeMov = 10;

    [Space(10)] //seoarar as variaveis no inspectro
    public Transform conector;

    [Range(0.1f,2f)]
    public float distanciaMinimaConector = 0.5f;
    bool Arratando;

    void Start()
    {
      _rigidbody2D = transform.root.GetComponent<Rigidbody2D>(); //pega o rigidbody do objeto pai   
      _rigidbody2D.gravityScale = 1;
    }

    private void OnMouseDown()
    {
        
    }
   
}
