using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemigo;
    public Transform generador;
    int posicionX;
    int posicionZ;
    public float posicionY;
    int numEnemigos;
    public int Enemigos;
    void Start()
    {
        StartCoroutine(SpawnEnemigos());
    }

    IEnumerator SpawnEnemigos()
    {
        while (numEnemigos < Enemigos)
        {
            if (Random.Range(0, 100) > 70)
            {
                posicionX = Random.Range(1, 20);
                posicionZ = Random.Range(1, 20);
                Instantiate(enemigo, new Vector3(generador.position.x + posicionX, posicionY,generador.position.z + posicionZ), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                
            }
            numEnemigos += 1;
        }                     
    }
}
