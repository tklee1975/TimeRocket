using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	public enum State 
	{
		Idle,
		Flying,
		Landing,
		Landed
	}

	[Header("General Setting")]
	public float zPosition = -5f;
	public float initialPosition = -3.5f;

	[Header("Flying Setting")]
	public float moveSpeed = 5.0f;
	public float maxMoveSpeed = 10.0f;
	public float acceleration = 10.0f;
	public float moveBound = 50;


	[Header("Landing Setting")]
	public Vector3 landingStartPosition = new Vector3(-1, 1, 0);
	public float landingDuration = 1.0f;

	[Header("Particle Setting")]
	public ParticleSystem boosterParticle;


	protected float mLandingTimeElapse = 0;
	protected Vector3 landingEndPosition;

	protected bool mMoving = false;
	

	protected State mState = State.Idle;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		Idle();
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		if(State.Flying == mState) {
			FixedUpdateFlying();
		} else if(State.Landing == mState) {
			FixedUpdateLanding();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MoveUp() {
		float moveDelta = moveSpeed * Time.deltaTime;
		Vector3 pos = transform.position;
		pos.y += moveDelta;
		if(pos.y >= moveBound) {
			pos.y = moveBound;
		}

		transform.position = pos;
	}



	public void StartMove(){
		mMoving = true;
	}
	public void StopMove() {
		mMoving = false;
	}

	void ResetPosition() {
		transform.position = new Vector3(0, initialPosition, zPosition);
	}

	void SetBoosterParticle(bool flag) {
		if(flag) {
			boosterParticle.Play();
		} else {
			boosterParticle.Stop();
			boosterParticle.Clear();
		}
	}

	#region Idle
	public void Idle() {
		mState = State.Idle;
		StopMove();
		SetBoosterParticle(false);
		ResetPosition();

		NotifyStateChange();
	}

	#endregion

	#region Flying
	public void Flying() {
		mState = State.Flying;
		SetBoosterParticle(true);

		NotifyStateChange();
	}	

	protected void FixedUpdateFlying() {
		MoveUp();
	}

	#endregion

	#region Landing
	public void Landing() {
		mState = State.Landing;
		//Vector3 startLandPos = landingStartPosition;

		SetBoosterParticle(false);
		landingEndPosition = new Vector3(0, initialPosition, zPosition);
		landingStartPosition.z = zPosition;	// fix the z position;
		mLandingTimeElapse = 0;
		transform.position = landingStartPosition;

		NotifyStateChange();
	}

	protected void FixedUpdateLanding() {
		mLandingTimeElapse += Time.fixedDeltaTime;

		float ratio = mLandingTimeElapse / landingDuration;
		if(ratio > 1) {
			ratio = 1;
		}

		transform.position = Vector3.Lerp(landingStartPosition, landingEndPosition, ratio);
		
		if(mLandingTimeElapse >= landingDuration) {
			Landed();
		}
	}

	#endregion

	public void Landed() {
		mState = State.Landed;
		NotifyStateChange();
	}


	public State state {
		get {
			return mState;
		}
	}

	#region Callback
	public delegate void StateCallback(State newState);

	public StateCallback onStateChanged = null;

	protected void NotifyStateChange() {
		if(onStateChanged != null) {
			onStateChanged(mState);
		}
	}

	#endregion
}
