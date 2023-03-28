using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject interfaz;
    public GameObject menuInicio;
    public GameObject menuOpciones;

    public AudioClip[] audios;
    public AudioSource audioSource;

    public AudioMixer masterMixer;
    public Slider sliderMaster;
    public Slider sliderMusica;
    public Slider sliderSonido;

    // Start is called before the first frame update
    void Start()
    {
        MenuInicio();
    }

    // Update is called once per frame
    void Update()
    {
        masterMixer.SetFloat("VolMaster", sliderMaster.value);
        masterMixer.SetFloat("VolMusica", sliderMusica.value);
        masterMixer.SetFloat("VolSonido", sliderSonido.value);
    }

    public void pausa()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audios[0]);
        menuPausa.SetActive(true);
        interfaz.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continuar()
    {
        audioSource.PlayOneShot(audios[0]);
        menuPausa.SetActive(false);
        interfaz.SetActive(true);

        Time.timeScale = 1;
    }
    public void Inicio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audios[0]);
        menuInicio.SetActive(false);
        interfaz.SetActive(true);
        Time.timeScale = 1;
        
    }
    public void MenuInicio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audios[0]);
        menuInicio.SetActive(true);
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
        Time.timeScale = 0;
        audioSource.PlayOneShot(audios[1]);
    }
    public void Opciones()
    {
        menuOpciones.SetActive(true);
        menuPausa.SetActive(false);
        menuInicio.SetActive(false);
        audioSource.PlayOneShot(audios[0]);
    }
    public void VolverOpciones()
    {
        menuOpciones.SetActive(false);
        menuPausa.SetActive(true);
        audioSource.PlayOneShot(audios[0]);
    }
    
    public void Salir() 
    {
        audioSource.PlayOneShot(audios[0]);
        Application.Quit();
    }

    public void ReiniciarJuego()
    {
        audioSource.PlayOneShot(audios[0]);
        SceneManager.LoadScene("SampleScene");
    }
}
