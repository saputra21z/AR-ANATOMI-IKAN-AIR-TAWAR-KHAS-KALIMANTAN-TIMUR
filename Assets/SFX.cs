

using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX Instance;
    private AudioSource audioSource;

    private bool isMuted = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("⚠️ AudioClip SFX kosong!");
            return;
        }

        if (!isMuted)
            audioSource.PlayOneShot(clip);
    }

    // ✅ Tambahan untuk mute/unmute
    public void SetMute(bool mute)
    {
        isMuted = mute;
        audioSource.mute = mute;
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
