using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    // Bu fonkdiyon sahneler arası geçişi sağlar (Start botunu ve bölümü seçimi için)
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Oyundan çıkış yapmak için kullanılan fonksiyon
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}
