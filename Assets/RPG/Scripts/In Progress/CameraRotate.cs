using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    public int RotateSpeed = 2;

	void Update ()
	{
        gameObject.transform.Rotate(new Vector3(0, RotateSpeed, 0) * Time.deltaTime, Space.World);
	}
}