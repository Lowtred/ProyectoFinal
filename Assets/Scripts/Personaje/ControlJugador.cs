using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    //InfoJugador
    public float danoPorGolpe;
    public float vidaJugador;
    float vidaActualJugador;
    float EnergiaActualJugador;

    //UI
    public Slider barraVida;
    public Slider barraEnergia;

    //Movimiento
    private float movHorizontal;
    private float movVertical;
    public CharacterController player;
    public float playerSpeed;

    //Animacion
    public Animator animator;

    public bool canMove;
    public GameObject colliderAtaque;

    void Start()
    {
        player = GetComponent<CharacterController>();
        vidaActualJugador = vidaJugador;
        barraVida.value = vidaActualJugador;
        EnergiaActualJugador = 10;
        barraEnergia.value = EnergiaActualJugador;
        Muevete();
    }
    
    // Update is called once per frame
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        movVertical = Input.GetAxis("Vertical");
        if (EnergiaActualJugador < 10)
        {
            EnergiaActualJugador += 0.001f;
            barraEnergia.value = EnergiaActualJugador;
        }
        if (Input.GetButtonDown("Fire1") && EnergiaActualJugador>=1)
        {
            animator.SetTrigger("Ataque");
        }
        
        if (canMove)
        {
            player.Move(new Vector3(movHorizontal, 0, movVertical) * playerSpeed * Time.deltaTime);
            animator.SetFloat("Camina", (Mathf.Abs(movVertical) + Mathf.Abs(movHorizontal)));
            //rotacion a puntero de mouse
            Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AtaqueEnemigo"))
        {
            if (vidaActualJugador > 0)
            {
                animator.SetTrigger("GolpeR");
                vidaActualJugador -= danoPorGolpe;
                barraVida.value = vidaActualJugador;
                //Debug.Log(vidaActualJugador);
            }

            if (vidaActualJugador <= 0)
            {
                barraVida.value = vidaActualJugador;
                animator.SetTrigger("Death");
                //Destroy(gameObject, 4);
            }
        }
    }
    public void Muevete()
    {
        canMove = true;
    }

    public void NoTeMuevas()
    {
        canMove = false;
    }

    public void Ataca()
    {
        colliderAtaque.SetActive(true);
        EnergiaActualJugador -= 2;
        barraEnergia.value = EnergiaActualJugador;
    }

    public void DejaDeAtacar()
    {
        colliderAtaque.SetActive(false);
    }
}
