﻿using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

  public Sound[] sounds;

  public static AudioManager instance;

  private void Awake() {

    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);

    foreach (Sound s in sounds) {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;
      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
      s.source.loop = s.loop;
    }
  }

  // Start is called before the first frame update
  void Start() {
    Play("Theme");
  }
  
  public void Play(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null) {
      Debug.LogWarning("Sound '" + name + "' not found.");
      return;
    }
    s.source.Play();
  }

  public void Pause(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null) {
      Debug.LogWarning("Sound '" + name + "' not found.");
      return;
    }
    s.source.Pause();
  }

  public void Resume(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null) {
      Debug.LogWarning("Sound '" + name + "' not found.");
      return;
    }
    s.source.UnPause();
  }
}
