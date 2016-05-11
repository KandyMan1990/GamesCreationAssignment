using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BossCharacter : MonoBehaviour
{
    public string Name;
    public string[] Messages;

    Camera cam;
    UnityStandardAssets.ImageEffects.Twirl twirl;
    UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration vignette;
    bool _encountered = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
        twirl = cam.GetComponent<UnityStandardAssets.ImageEffects.Twirl>();
        vignette = cam.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_encountered)
                {
                    _encountered = true;

                    foreach (string s in Messages)
                    {
                        QuestPopup.Instance.Popup(Name, s, 3, true);
                    }

                    StartCoroutine(CanBattle());
                }
            }
        }
    }

    IEnumerator CanBattle()
    {
        while (!QuestPopup.Instance.IsQueueEmpty)
            yield return null;

        StartCoroutine(TriggerEncounter());
    }

    IEnumerator TriggerEncounter()
    {
        audioSource.PlayOneShot(GameManager.Instance.System_DB.BossStartSFX);
        IntroloopPlayer.Instance.Play(GameManager.Instance.System_DB.BossMusic);

        while (twirl.center.x < 1)
        {
            twirl.center.x += (1f * Time.deltaTime) / 2;
            vignette.intensity += (0.5f * Time.deltaTime) / 2;
            vignette.blur += (0.5f * Time.deltaTime) / 2;
            vignette.chromaticAberration += (50 * Time.deltaTime) / 2;

            if (twirl.center.x >= 1)
                twirl.center.x = 1;

            if (vignette.intensity >= 1)
                vignette.intensity = 1;

            if (vignette.blur >= 1)
                vignette.blur = 1;

            if (vignette.chromaticAberration >= 100)
                vignette.chromaticAberration = 100;

            yield return 0;
        }

        while (audioSource.isPlaying)
        {
            yield return 0;
        }

        SceneManager.LoadScene("BossFight1");
    }
}