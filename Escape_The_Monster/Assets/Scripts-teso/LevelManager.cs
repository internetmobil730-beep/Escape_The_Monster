using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Ayarlar")]
    public Button[] levelButtons; // 15 adet butonu buraya sırayla sürükleyin
    public GameObject[] lockIcons; // 15 adet kilit ikonunu buraya sırayla sürükleyin

    void Start()
    {
        // Oyuncunun ilerlemesini (mevcut seviye) ve toplam puanını getir
        // "ReachedLevel" anahtarı yoksa varsayılan olarak 1 döner
        int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);
        int totalPoints = PlayerPrefs.GetInt("TotalPoints", 0);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int currentLevelNum = i + 1;

            // Varsayılan Durum: Buton kapalı ve kilit ikonu görünür
            levelButtons[i].interactable = false;
            if (lockIcons[i] != null) lockIcons[i].SetActive(true);

            // İlerlemeye göre seviyeleri aç
            if (currentLevelNum <= reachedLevel)
            {
                levelButtons[i].interactable = true;
                if (lockIcons[i] != null) lockIcons[i].SetActive(false);

                // Özel puan şartları (6. ve 11. seviyeler için)
                if (currentLevelNum == 6 && totalPoints < 50) LockLevel(i);
                if (currentLevelNum == 11 && totalPoints < 100) LockLevel(i);
            }
        }
    }

    // Seviyeyi kilitlemek için yardımcı fonksiyon
    void LockLevel(int index)
    {
        levelButtons[index].interactable = false;
        if (lockIcons[index] != null) lockIcons[index].SetActive(true);
    }

    // Butona tıklandığında ilgili sahneyi yükleyen fonksiyon
    public void OpenLevel(int levelIndex)
    {
        // Sahne isimlerinin "Level-1", "Level-2" şeklinde olduğundan emin olun
        SceneManager.LoadScene("Level-" + levelIndex);
    }
}
