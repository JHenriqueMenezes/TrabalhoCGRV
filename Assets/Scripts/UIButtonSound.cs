using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonHoverSFX();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioManager != null)
        {
            audioManager.PlayButtonClickSFX();
        }
    }
}
