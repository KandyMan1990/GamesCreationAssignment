using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]
public class BattleTrigger : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;
    // Percentage rate at which random battles will occur
    public float EncounterRate = 0.5f;

    bool canCheckForEncounter;
    Animator anim;
    UnityStandardAssets.ImageEffects.Twirl twirl;
    UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration vignette;
    float rand;
    AudioSource audioSource;

    void Start()
    {
        anim = Player.GetComponent<Animator>();
        canCheckForEncounter = true;
        twirl = cam.GetComponent<UnityStandardAssets.ImageEffects.Twirl>();
        vignette = cam.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();
        audioSource = GetComponent<AudioSource>();

        twirl.center.x = -1;
        vignette.intensity = 0;
        vignette.blur = 0;
        vignette.chromaticAberration = 0;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (anim.GetFloat("speed") > 0)
            {
                Debug.Log("In trigger zone & moving, potential for encounter");

                if(canCheckForEncounter)
                    CheckForEncounter();
            }
            else
                Debug.Log("In trigger zone");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("In trigger zone");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Not in trigger volume");
        }
    }

    void CheckForEncounter()
    {
        rand = Random.Range(0, 99);

        if (rand < EncounterRate)
            StartCoroutine(TriggerEncounter());
    }

    IEnumerator TriggerEncounter()
    {
        anim.SetFloat("speed", 0);
        anim.gameObject.GetComponent<overlordcontrol>().enabled = false;
        

        canCheckForEncounter = false;

        audioSource.PlayOneShot(GameManager.Instance.System_DB.BattleStartSFX);
        IntroloopPlayer.Instance.Play(GameManager.Instance.System_DB.BattleMusic);

        while (twirl.center.x < 1)
        {
            twirl.center.x += 1f * Time.deltaTime;
            vignette.intensity += 0.5f * Time.deltaTime;
            vignette.blur += 0.5f * Time.deltaTime;
            vignette.chromaticAberration += 50 * Time.deltaTime;

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

        while(audioSource.isPlaying)
        {
            yield return 0;
        }

        SceneManager.LoadScene("Experimental");
    }
}