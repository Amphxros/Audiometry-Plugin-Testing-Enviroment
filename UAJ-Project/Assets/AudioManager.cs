using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start() {
        Debug.Log(HearingTest.frequency);
        audioMixer.FindMatchingGroups("Master")[0].audioMixer.SetFloat("masterVol", HearingTest.volume);
        audioMixer.FindMatchingGroups("Master")[0].audioMixer.SetFloat("frequencyGain", HearingTest.frequency);
    }

}
