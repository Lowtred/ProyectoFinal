using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNaturaleza : MonoBehaviour
{
    public Transform generador;
    public GameObject[] objeto;
    void Start()
    {

        Instantiate(objeto[Random.Range(0,objeto.Length)], new Vector3(generador.position.x, 0, generador.position.z), new Quaternion(0, 0, 0, 0));
        //Destruye generador usado
        Destroy(gameObject);
    }


}
