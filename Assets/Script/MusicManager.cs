using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager Instance;

    bool muted = false;

    AudioSource audioSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateMuteStatus();
        if (muted)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = 1;
        }
    }

    private void UpdateMuteStatus()
    {
        muted = (PlayerPrefs.GetInt("muteMusic", 0) != 0) ; // Workaround playerprefs buat nyimpan bool
    }
}
