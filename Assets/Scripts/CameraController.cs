using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    
	
	// Update is called once per frame
	void LateUpdate ()
    {
        UpdateCamera();
	}


    void UpdateCamera()
    {
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = transform.position.x;
        Camera.main.transform.position = newCameraPos;
    }
}
