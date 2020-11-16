using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CotroleDoJogador : MonoBehaviour
{
    public float Velocidade = 4;
    Vector3 Direção;
    // cor 0 = Jogador
    // cor 1 = Verde
    public Material[] Cores;
    bool EstouVerde = false;

    float Tempo = 0;
    float TempoLimite = 15/10;

    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Tempo += Time.deltaTime;
        Direção = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(Direção * Velocidade * Time.deltaTime);

        if (Tempo > TempoLimite)
        {
            r.material = Cores[0];
            EstouVerde = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Vitoria();
        }
        
        if (other.GetComponent<Vermelho>() != null)
        {
            FimDeJogo();
        }
        else if (other.GetComponent<Verde>() != null)
        {
            print(r.material);
            print(other.GetComponent<Renderer>().material);
            if (EstouVerde)
            {
                FimDeJogo();
            }
            else 
            {
                r.material = Cores[1];
                transform.localScale *= 15/10;
                EstouVerde = true;
                Tempo = 0;
            }
                
        }
    }

    private void Vitoria()
    {
        r.enabled = false;
        Time.timeScale = 0;
        print("Parabéns!!");
    }

    private void FimDeJogo()
    {
        r.enabled = false;
        Time.timeScale = 0;
        print("Fim de jogo. Tente Novamente.");
    }
}