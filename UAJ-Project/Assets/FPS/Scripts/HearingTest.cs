using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HearingTest : MonoBehaviour
{
    public static float frequency, volume;

    public Slider slider;

    public void SetFrequency(float _frequency)
    {
        frequency = _frequency;
        Debug.Log("frequency: " + frequency);
    }

    public void SetVolume()
    {
        volume = (slider.value * 100) - 20;
        slider.GetComponent<AudioSource>().volume = slider.value;
        slider.GetComponent<AudioSource>().Play();
        Debug.Log("volume: " + volume);
    }

    public void PlaySound(GameObject go)
    {
        go.GetComponent<AudioSource>().Play();
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
     
}
