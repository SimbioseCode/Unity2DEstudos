using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=EohhGbRgNds
//necessario boxcollider
[RequireComponent(typeof(Rigidbody2D))]
public class Letras : MonoBehaviour //FUNCIONA APENAS COM CAMERA ORTOGRAFICAS
{
    Vector3 posInicial;
    Vector3 posDestino;
    Vector3 vetorDirecao;
    Rigidbody2D _rigidbody2D;
    bool estaArrastando;
    float distancia;

    [HideInInspector]//deixa publica mas nao aparece no inspectro 
    public bool estaConectado;
    
    [Range(1,15)]//limitar o valor que a variavel pode obter
    public float velocidadeMov = 10;

    [Space(10)] //seoarar as variaveis no inspectro
    public Transform conector;

    [Range(1.0f,2.0f)]
    public float distanciaMinimaConector = 1.0f;
    bool Arratando;

    void Start() {
      _rigidbody2D = transform.root.GetComponent<Rigidbody2D>(); //pega o rigidbody do objeto pai   
      _rigidbody2D.gravityScale = 1; //desativar a gravidade
    }

    void OnMouseDown(){
        posInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2D.gravityScale = 0;
        estaArrastando = true;
        estaConectado = false;
        //Debug.Log("teste");
    }

    void OnMouseDrag()  {
         posDestino =  posInicial +  Camera.main.ScreenToWorldPoint(Input.mousePosition);
         vetorDirecao = posDestino - transform.root.position;
         _rigidbody2D.velocity = vetorDirecao * velocidadeMov;
    }

    void OnMouseUp()
    {
        _rigidbody2D.gravityScale = 1;
        estaArrastando = false;        
    }
    void FixedUpdate()
    {
        if(!estaArrastando && !estaConectado){
            distancia = Vector2.Distance(transform.root.position, conector.position);
            if(distancia < distanciaMinimaConector){
                _rigidbody2D.gravityScale = 0;
                _rigidbody2D.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.05f); // nao precisa de delta time pq nao esta na void updade 
            }
            if(distancia < 0.01f){
                estaConectado = true;
                transform.root.position = conector.position;
            }
        }
    }
}
