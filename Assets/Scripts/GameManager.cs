using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public GameObject menuPusa;
    public GameObject interfaz;
    public GameObject menuInicio;

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
    //void Update()
    //{
        
    //}

    public void pausa()
    {
        audioSource.PlayOneShot(audios[0]);
        menuPusa.SetActive(true);
        interfaz.SetActive(false);
        Time.timeScale = 0;
    }

    public void Continuar()
    {
        audioSource.PlayOneShot(audios[0]);
        menuPusa.SetActive(false);
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
        menuPusa.SetActive(false);
        Time.timeScale = 0;
        audioSource.PlayOneShot(audios[1]);
    }
    public void Salir() 
    {
        audioSource.PlayOneShot(audios[0]);
        Application.Quit();
    }
}
