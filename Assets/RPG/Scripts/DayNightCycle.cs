using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float RotateSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(RotateSpeed * Time.deltaTime, 0f, 0f);
    }
}