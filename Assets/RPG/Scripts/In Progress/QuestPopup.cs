using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestPopup : MonoBehaviour
{
    private static QuestPopup _instance;

    public static QuestPopup Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (QuestPopup)FindObjectOfType(typeof(QuestPopup));
            }

            if (_instance == null)
            {
                GameObject templatePrefab = Resources.Load("QuestPopup") as GameObject;

                GameObject questPopup = Instantiate(templatePrefab);

                _instance = questPopup.GetComponent<QuestPopup>();
            }

            return _instance;
        }
    }

    public GameObject CanvasPanel;
    public Text Name;
    public Text Message;

    private bool _canPopup = true;

    void Awake()
    {
        Object[] QuestPopups = FindObjectsOfType(typeof(QuestPopup));
        for (int i = 0; i < QuestPopups.Length; i++)
        {
            if(QuestPopups[i] != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        CanvasPanel.SetActive(false);
    }

    public void Popup(string name, string text, float popupLength)
    {
        if(_canPopup)
            StartCoroutine(PopupFunction(name, text, popupLength));
    }

    IEnumerator PopupFunction(string charName, string charText, float length)
    {
        _canPopup = false;

        Name.text = charName;
        Message.text = charText;

        CanvasPanel.SetActive(true);

        yield return new WaitForSeconds(length);

        CanvasPanel.SetActive(false);
        _canPopup = true;
    }
}