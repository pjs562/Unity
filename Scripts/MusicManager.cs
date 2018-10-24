using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour {

    public Slider MusicVolume;
    public AudioSource myMusic;
    public Slider SoundVolume;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        myMusic.volume = MusicVolume.value;
    }
}
