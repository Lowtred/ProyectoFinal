using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorRB : MonoBehaviour
{
    public GameObject generadorR;
    public GameObject generadorRT;
    public GameObject generadorRB;
    public GameObject generadorL;
    //public GameObject generadorLT;
    public GameObject generadorLB;

    public Transform generador;
    public GameObject[] terreno;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GeneraTerrenoNuevo
            Instantiate(terreno[Random.Range(0, terreno.Length)], new Vector3(generador.position.x + 12.99038f, 0, generador.position.z - 22.5f), new Quaternion(-1, 0, 0, 1));

            //Crea nuevo generadorR
            Instantiate(generadorR, new Vector3(generador.position.x + 38.97114f, 0, generador.position.z - 22.5f), new Quaternion(-1, 0, 0, 1));

            //Crea nuevo generadorL 
            Instantiate(generadorL, new Vector3(generador.position.x - 12.99038f, 0, generador.position.z - 22.5f), new Quaternion(-1, 0, 0, 1));

            //Crea nuevo generadorRT 
            Instantiate(generadorRT, new Vector3(generador.position.x + 25.98076f, 0, generador.position.z), new Quaternion(-1, 0, 0, 1));

            //Crea nuevo generadorLT 
            //Instantiate(generadorLT, new Vector3(generador.position.x, 0, generador.position.z + 45f), new Quaternion(-1, 0, 0, 1));

            //Crea nuevo generadorLB 
            Instantiate(generadorLB, new Vector3(generador.position.x, 0, generador.position.z - 45f), new Quaternion(-1, 0, 0, 1));

            //Crea nuevo generadorRB 
            Instantiate(generadorRB, new Vector3(generador.position.x + 25.98076f, 0, generador.position.z - 45f), new Quaternion(-1, 0, 0, 1));

            //Destruye generador usado
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
