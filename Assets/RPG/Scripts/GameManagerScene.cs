using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScene : MonoBehaviour
{
    public GameObject Camera;

    // Use this for initialization
    void Start()
    {
        Destroy(Camera);
    }
}