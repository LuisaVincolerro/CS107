using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorPula : MonoBehaviour
{
    public Vector3 direção;
    public float força;
    Rigidbody comportamento_físico;

    // Start is called before the first frame update
    void Start()
    {
        comportamento_físico = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // click esquerdo é 0, e o direito é 1 (documentação da Unity)
        if (Input.GetMouseButtonDown(0))
        {
            comportamento_físico.AddForce(direção * força);
        }

    }
}
