using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void GoBackToBiawanPopUp()
    {

        // Load scene Main Menu
        SceneManager.LoadScene("Main Menu");

        // Simpan info kalau user datang dari Detail AR Biawan
        PlayerPrefs.SetString("LastAR", "Detail Ar Biawan");

    }

    public void GoBackToHaruanPopUp()
    {

        // Load scene Main Menu
        SceneManager.LoadScene("Main Menu");

        // Simpan info kalau user datang dari Detail AR Biawan
        PlayerPrefs.SetString("LastAR", "Detail Ar Haruan");

    }

    public void GoBackToBetutuPopUp()
    {

        // Load scene Main Menu
        SceneManager.LoadScene("Main Menu");

        // Simpan info kalau user datang dari Detail AR Biawan
        PlayerPrefs.SetString("LastAR", "Detail Ar Betutu");

    }

}
