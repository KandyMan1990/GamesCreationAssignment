using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestPopup : MonoBehaviour
{
    private class QuestObject
    {
        public string Name;
        public string Text;
        public float Length;
        public bool IsSpeech;

        public QuestObject(string name, string text, float length, bool isSpeech)
        {
            Name = name;
            Text = text;
            Length = length;
            IsSpeech = isSpeech;
        }
    }

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

    private bool _isProcessing = false;
    private Queue<QuestObject> queue = new Queue<QuestObject>();
    private GameObject player;

    void Awake()
    {
        Object[] QuestPopups = FindObjectsOfType(typeof(QuestPopup));
        for (int i = 0; i < QuestPopups.Length; i++)
        {
            if (QuestPopups[i] != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        CanvasPanel.SetActive(false);
    }

    public void Popup(string name, string text, float popupLength, bool isSpeech)
    {
        queue.Enqueue(new QuestObject(name, text, popupLength, isSpeech));

        if(!_isProcessing)
            StartCoroutine(PopupFunction());
    }

    IEnumerator PopupFunction()
    {
        WaitForSeconds letterPause = new WaitForSeconds(0.03f);

        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            player.GetComponent<Animator>().SetFloat("speed", 0);
            player.GetComponent<overlordcontrol>().enabled = false;
        }

        _isProcessing = true;

        while(queue.Count > 0)
        {
            CanvasPanel.transform.localScale = new Vector3(0, 0, 0);
            Name.text = string.Empty;
            Message.text = string.Empty;

            CanvasPanel.SetActive(true);

            float time = 0f;
            while (time < 1)
            {
                time += 3.5f * Time.deltaTime;
                CanvasPanel.transform.localScale = new Vector3(time, time, time);
                yield return null;
            }
            CanvasPanel.transform.localScale = new Vector3(1, 1, 1);


            foreach (char letter in queue.Peek().Name.ToCharArray())
            {
                Name.text += letter;
                yield return letterPause;
            }
            if(queue.Peek().IsSpeech)
                Message.text = '"'.ToString();
            foreach (char letter in queue.Peek().Text.ToCharArray())
            {
                Message.text += letter;
                yield return letterPause;
            }
            if (queue.Peek().IsSpeech)
                Message.text += '"'.ToString();
            yield return new WaitForSeconds(queue.Peek().Length);


            Name.text = string.Empty;
            Message.text = string.Empty;
            time = 1f;
            while (time > 0)
            {
                time -= 3.5f * Time.deltaTime;
                CanvasPanel.transform.localScale = new Vector3(time, time, time);
                yield return null;
            }
            CanvasPanel.transform.localScale = new Vector3(0, 0, 0);

            CanvasPanel.SetActive(false);
            queue.Dequeue();
        }

        _isProcessing = false;

        if(player!= null)
            player.GetComponent<overlordcontrol>().enabled = true;
    }

    public bool IsQueueEmpty
    {
        get
        {
            if (queue.Count > 0)
                return false;
            else
                return true;
        }
    }

    public bool IsProcessing
    {
        get { return _isProcessing; }
    }
}