using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider MusicVolume;
    public AudioSource myMusic;
    public Slider SoundVolume;
    public AudioSource[] mySound;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        myMusic.volume = MusicVolume.value;
        for (int i = 0; i < mySound.Length; i++)
        { 
            mySound[i].volume = SoundVolume.value; 
        }

    }
}
