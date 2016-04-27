using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonScript : MonoBehaviour, IPointerEnterHandler
{
    public bool IsCancelButton = false;
    public bool IsNewGameButton = false;

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

    public void OnClick()
    {
        if (btn.IsInteractable())
        {
            if (IsNewGameButton)
                audioSource.PlayOneShot(GameManager.Instance.System_DB.NewGameSFX);
            else if (IsCancelButton)
                audioSource.PlayOneShot(GameManager.Instance.System_DB.CancelSFX);
            else
                audioSource.PlayOneShot(GameManager.Instance.System_DB.OkSFX);
        }
        else if (!btn.IsInteractable())
            audioSource.PlayOneShot(GameManager.Instance.System_DB.ErrorSFX);
    }
}