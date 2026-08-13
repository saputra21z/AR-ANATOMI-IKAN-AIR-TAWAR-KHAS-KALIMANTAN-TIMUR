
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public static BGM Instance;   // Singleton
    private AudioSource audioSource;

    [Header("Stop Musik di Scene Tertentu")]
    public string[] SilenceScenes = { "Detail Ar Internal Biawan", "Detail Ar External Haruan" };
    // Tambah scene lain kalau perlu

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }

            // 🔑 Tambahkan listener ke event pergantian scene
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Hapus duplikat
        }
    }

    void OnDestroy()
    {
        // Lepaskan listener saat object dihancurkan
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 🔥 Fungsi dipanggil setiap kali scene baru diload
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (IsSilenceScene(scene.name))
        {
            StopMusic();  // Matikan musik
        }
        else
        {
            PlayMusic();  // Hidupkan musik lagi
        }
    }

    // ✅ Cek apakah scene ada di daftar mute
    private bool IsSilenceScene(string sceneName)
    {
        foreach (string s in SilenceScenes)
        {
            if (sceneName == s)
                return true;
        }
        return false;
    }

    // 🔊 Kontrol musik
    public void SetMute(bool mute)
    {
        if (audioSource != null)
            audioSource.mute = mute;
    }

    public bool IsMuted()
    {
        return audioSource != null && audioSource.mute;
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }

    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Pause();
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
    }

    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
}
