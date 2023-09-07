using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonDestroyMono<SoundManager>
{
    public AudioClip tvZip;
    public AudioClip lightSwitch;
    public List<AudioClip> tvShows = new List<AudioClip>();
}
