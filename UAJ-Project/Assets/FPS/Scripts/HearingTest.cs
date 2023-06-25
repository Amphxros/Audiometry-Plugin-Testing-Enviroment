using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HearingTest : MonoBehaviour
{
    public static float frequency, volume;

    public AudioSource[] go;

    public Slider slider;

    public void SetFrequency(float _frequency)
    {
        frequency = _frequency;
        volume = -20 + frequency;
        Debug.Log("frequency: " + frequency);
        Debug.Log("volume: " + volume);
    }

    public void SetVolume()
    {
        volume = (slider.value * 100) - 20;
        var i = slider.value <= 0 ? slider.GetComponent<AudioSource>().volume = volume : slider.GetComponent<AudioSource>().volume = volume - 50;
        slider.GetComponent<AudioSource>().Play();
        Debug.Log("volume: " + volume);
    }

    public void PlaySound(AudioSource audio)
    {
        foreach(AudioSource aud in go)
        {
            if (aud != audio)
            {
                aud.Stop();
                Debug.Log(1);
            }
            else
            {
                Debug.Log(2);
                aud.Play();
            }
        } 
    }

    public void Continue()
    {
        string scene = "MainScene";
        SceneManager.LoadScene(scene LoadSceneMode.Single);
    }
     
}
