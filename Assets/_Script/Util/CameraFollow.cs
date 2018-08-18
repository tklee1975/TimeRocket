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

    protected bool mEnable = false;
    protected Vector3 mOriginPosition;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        mOriginPosition = transform.position;
    }
    

    void Start ()
    {
    }

    

    public void ResetOrigin() {
        transform.position = mOriginPosition;   
    }

    public void SetEnable(bool flag) {
        mEnable = flag;
    }
		
    void FixedUpdate ()
    {
        if(target == null) {
            return;
        }
    

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
