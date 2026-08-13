
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    [Header("Sound Effect")]
    public AudioClip buttonClickSFX;

    public void LoadScene(string sceneName)
    {
        PlayClickSFX();
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenu() => LoadScene("main menu");
    public void LoadSlide() => LoadScene("Slide");
    public void LoadInternalBiawan() => LoadScene("Detail Ar Internal Biawan");
    public void LoadExternalBiawan() => LoadScene("Detail Ar External Biawan");
    public void LoadInternalHaruan() => LoadScene("Detail Ar Internal Haruan");
    public void LoadExternalHaruan() => LoadScene("Detail Ar External Haruan");
    public void LoadExternalBetutu() => LoadScene("Detail Ar External Betutu");
    public void LoadInternalBetutu() => LoadScene("Detail Ar Internal Betutu");
    public void LoadInformasiInternalBiawan() => LoadScene("Slide Informasi Internal Biawan");
    public void LoadInformasiExternalBiawan() => LoadScene("Slide Informasi External Biawan");
    public void LoadInformasiInternalHaruan() => LoadScene("Slide Informasi Internal Haruan");
    public void LoadInformasiExternalHaruan() => LoadScene("Slide Informasi External Haruan");
    public void LoadInformasiInternalBetutu() => LoadScene("Slide Informasi Internal Betutu");
    public void LoadInformasiExternalBetutu() => LoadScene("Slide Informasi External Betutu");

    private void PlayClickSFX()
    {
        if (SFX.Instance != null && buttonClickSFX != null)
        {
            SFX.Instance.PlaySFX(buttonClickSFX);
        }
        else
        {
            if (SFX.Instance == null)
                Debug.LogWarning("⚠️ SFX Manager tidak ditemukan di scene!");
            if (buttonClickSFX == null)
                Debug.LogWarning("⚠️ AudioClip Button Click SFX belum di-assign!");
        }
    }
}
