using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    public Vector3 Direção;
    public float Velocidade;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direção * Velocidade * Time.deltaTime);    
    }
}
