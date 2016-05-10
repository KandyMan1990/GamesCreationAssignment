using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour
{
    public IntroloopAudio Music;

	void Start ()
	{
        IntroloopPlayer.Instance.PlayFade(Music, 1f);
	}
}