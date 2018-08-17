//This script enables the camera to follow a target's position smoothly. It doesn't copy the 
//target's rotation so that it maintains the same view angle

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // The target that that camera will be following.
    public float speed = 5f;	// The speed with which the camera will be following.

    Vector3 offset;				// The initial offset from the target.
    public float bottomBound = 0;
    public float leftBound = -3;
    public float rightBound = 3;
    

    void Start ()
    {
        //Record the camera's initial position offset from the target.
		//The camer will then maintain this offset
        offset = transform.position - target.position;
    }
		
    void FixedUpdate ()
    {
    	//Figure out where the camera wants to be by adding the offset to the target's current
		//position
    	Vector3 targetCamPos = target.position;
        targetCamPos.z = -10;
        if(targetCamPos.y < bottomBound) {
            targetCamPos.y = bottomBound;
        }
        targetCamPos.x = Mathf.Clamp(target.position.x, leftBound, rightBound);

		// Smoothly interpolate (move) between the camera's current position and it's target position.
    	transform.position = targetCamPos; 
        // Vector3.Lerp (transform.position, targetCamPos, speed * Time.deltaTime);
        // transform.LookAt(target);
    }
}
