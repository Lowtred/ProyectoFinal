using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNaturaleza : MonoBehaviour
{
    public Transform generador;
    public GameObject[] objeto;

    public int probabilidadGenerar;
    int prob;
    void Start()
    {
        prob = Random.Range(0, 101);
        if (prob >= (100-probabilidadGenerar)) { 
        Instantiate(objeto[Random.Range(0,objeto.Length)], new Vector3(generador.position.x, 0, generador.position.z), new Quaternion(0, 0, 0, 0));
        }
        Destroy(gameObject);
    }
}
