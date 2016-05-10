using UnityEngine;
using System.Collections;

public class CameraPoint : MonoBehaviour
{
    public string Text;
    public float ShowLength = 3f;
    public void ShowText()
    {
        QuestPopup.Instance.Popup("Guide", Text, ShowLength);
    }
}