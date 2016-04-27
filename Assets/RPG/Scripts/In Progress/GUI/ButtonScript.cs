using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler
{
    public bool IsCancelButton = false;

    private Button btn;
    private AudioSource audioSource;

    void Start()
    {
        btn = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (btn.IsInteractable())
            audioSource.PlayOneShot(GameManager.Instance.System_DB.CursorSFX);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!btn.IsInteractable())
            audioSource.PlayOneShot(GameManager.Instance.System_DB.ErrorSFX);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (btn.IsInteractable())
        {
            if (!IsCancelButton)
                audioSource.PlayOneShot(GameManager.Instance.System_DB.OkSFX);
            else
                audioSource.PlayOneShot(GameManager.Instance.System_DB.CancelSFX);
        }
    }
}