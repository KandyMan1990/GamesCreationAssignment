using UnityEngine;
using System.Collections;

public class SceneLoaded : MonoBehaviour
{
    public IntroloopAudio BGM;

	void Start ()
	{
        IntroloopPlayer.Instance.Play(BGM);
	}
}