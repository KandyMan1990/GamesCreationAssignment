using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadPlayerLocation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == GameManager.Instance.GetSceneName)
        {
            if (GameManager.Instance.GetPlayerPosition != Vector3.zero)
            {
                transform.localPosition = GameManager.Instance.GetPlayerPosition;
                transform.localEulerAngles = GameManager.Instance.GetPlayerRotation;

                GameManager.Instance.ClearPlayerPositionRotationAndScene();
            }
        }
    }
}