using UnityEngine;

public class RotateSelector : MonoBehaviour
{
    public float RotateSpeed = 5f;

    void Update()
    {
        transform.Rotate(0f, RotateSpeed, 0f);
    }
}