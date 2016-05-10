using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraIntro : MonoBehaviour
{
    public float CamSpeed = 8f;
    public Image panel;
    public IntroloopAudio Music;

    CameraPoints points;
    Color col;

	void Start ()
	{
        points = GameObject.Find("Camera Points").GetComponent<CameraPoints>();

        col = panel.color;
        col.a = 1;
        panel.color = col;

        IntroloopPlayer.Instance.PlayFade(Music, 3f);
        StartCoroutine(MoveToPoint());
	}
	
    IEnumerator MoveToPoint()
    {
        for(int i = 0; i < points.Points.Length; i++)
        {
            if(IsEven(i))
            {
                StartCoroutine(Fade(true));
            }
            else
            {
                StartCoroutine(Fade(false));
            }
            points.Points[i].GetComponent<CameraPoint>().ShowText();
            while (moveTowards(points.Points[i].transform.position))
            {
                yield return null;
            }
        }
        while(!QuestPopup.Instance.IsQueueEmpty)
        {
            yield return null;
        }
        IntroloopPlayer.Instance.StopFade(2f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync("RoamingScene");
    }

    bool moveTowards(Vector3 pos)
    {
        return pos != (transform.position = Vector3.MoveTowards(transform.position, pos, CamSpeed * Time.deltaTime));
    }

    IEnumerator Fade(bool fadeIn)
    {
        if(fadeIn)
        {
            while(col.a > 0)
            {
                col.a -= 0.3f * Time.deltaTime;
                panel.color = col;
                yield return null;
            }
        }
        else
        {
            while (col.a < 1)
            {
                col.a += 0.3f * Time.deltaTime;
                panel.color = col;
                yield return null;
            }
        }
    }

    bool IsEven(int value)
    {
        return value % 2 == 0;
    }
}