using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static AudioSource source;

	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	public static void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
