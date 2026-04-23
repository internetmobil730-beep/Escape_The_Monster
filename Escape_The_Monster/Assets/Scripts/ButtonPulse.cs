using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Mouse etkileşimlerini (tıklama , üzerine gelme) kontrol etmek için gerekli

public class ButtonPulse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale; // Butonun başlangıçtaki original boyutunu saklar
    public float scaleFaktor = 1.1f; // Butonun ne kadar büyüyeceğeni belirleyen çarpan (1.1 = %10 büyüme)
   
    void Start()
    {
        // Oyun başlandığında butonun original boyutunu kaydeder
        originalScale = transform.localScale;  
    }

    // Mouse butonnun üzerine geldiğinde çalışır
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Butonun belirlenen oranda büyütür
        transform.localScale = originalScale * scaleFaktor;
    }

    // Mouse butondan çekildiğinde çalışır
    public void OnPointerExit(PointerEventData eventData)
    {
        // Butonu tekrar eski (original) boyutuna döndürür
        transform.localScale = originalScale;
        transform.localScale = originalScale;
    }
}
