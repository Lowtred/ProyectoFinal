using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Bandido : MonoBehaviour
{
    //InfoEnemigo
    public float danoPorGolpe;
    public float vidaDelEnemigo;
    float vidaActualEnemigo;
    //EstadosEnemigo
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    private bool estarAlerta;
    public Transform jugador;
    public float velocidad;
    //Animaciones
    public Animator animator;
    public string variableGolpear;
    public string variableMovimiento;
    public string variableDano;
    public string variableMorir;


    //LogicaAtaque
    bool enMovimiento = false;
    bool canMove = true;
    public GameObject colliderAtaque;

    //UI
    public Slider barraVidaEnemigo;

    //Sonido
    public AudioClip[] audios;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        vidaActualEnemigo = vidaDelEnemigo;
        barraVidaEnemigo.value = vidaActualEnemigo;
        jugador = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
            if (estarAlerta == true)
            {
                if (enMovimiento == false)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(audios[0]);
                    animator.SetBool(variableMovimiento, true);
                    enMovimiento = true;
                }
                Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
                transform.LookAt(posJugador);
                transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
            }
            else
            {
                if (enMovimiento == true)
                {
                    animator.SetBool(variableMovimiento, false);
                    enMovimiento = false;
                }
            }
        }

    }

    //Detector de golpes recibidos
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaqueJugador"))
        {
            if (vidaActualEnemigo > 0)
            {
                animator.SetTrigger(variableDano);
                //audioSource.PlayOneShot(audios[0]);
                vidaActualEnemigo -= danoPorGolpe;
                barraVidaEnemigo.value = vidaActualEnemigo;
            }

            if (vidaActualEnemigo <= 0)
            {
                animator.SetTrigger(variableMorir);
                //audioSource.PlayOneShot(audios[1]);
                Destroy(gameObject, 4);
            }
        }
    }

    //Golpeando

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Contacto con jugador");
            animator.SetTrigger(variableGolpear);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    public void Ataca()
    {
        colliderAtaque.SetActive(true);
        //audioSource.PlayOneShot(audios[2]);
    }

    public void DejaDeAtacar()
    {

        colliderAtaque.SetActive(false);
    }

    public void Muevete()
    {
        canMove = true;
    }

    public void NoTeMuevas()
    {
        canMove = false;
        animator.SetBool(variableMovimiento, false);
        enMovimiento = false;
    }
}
