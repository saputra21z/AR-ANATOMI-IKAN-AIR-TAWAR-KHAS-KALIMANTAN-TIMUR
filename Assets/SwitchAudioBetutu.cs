using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchAudioBetutu : MonoBehaviour
{
    [Header("Tombol UI Backsound")]
    public Image On;    // ikon ON musik
    public Image Off;   // ikon OFF musik

    [Header("Audio Backsound")]
    public AudioSource bgmSource; // drag AudioSource backsound ke sini lewat Inspector

    void Start()
    {
        // Saat awal, musik OFF (tidak berbunyi)
        On.gameObject.SetActive(false);
        Off.gameObject.SetActive(true);

        if (bgmSource != null)
            bgmSource.Stop(); // pastikan backsound diam di awal
    }

    // 🔇 Matikan musik (backsound)
    public void SetMusikOff()
    {
        On.gameObject.SetActive(false);
        Off.gameObject.SetActive(true);
        Debug.Log("Musik Betutu OFF");

        if (bgmSource != null)
            bgmSource.Pause(); // hentikan backsound
    }

    // 🔊 Nyalakan musik (backsound)
    public void SetMusikOn()
    {
        On.gameObject.SetActive(true);
        Off.gameObject.SetActive(false);
        Debug.Log("Musik Betutu ON");

        if (bgmSource != null)
        {
            if (!bgmSource.isPlaying)
                bgmSource.Play(); // baru mulai main setelah tombol ditekan
        }
    }
}
