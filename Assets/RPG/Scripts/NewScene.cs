using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);
    }
}