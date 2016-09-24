using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float maxSpeed;
	public Vector2 originalScale;
	public Vector2 currentScale;
	private Rigidbody2D ballRigidBody;
	// Use this for initialization
	void Start () {
		ballRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
		originalScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		CapMaxSpeed();
	}

	public void Caught(Transform parent){
		ballRigidBody.isKinematic = true;
		ballRigidBody.GetComponent<Collider2D>().enabled = false;

		this.transform.SetParent(parent); 
	}

	public void Release(Vector2 releaseVelocity){
		ballRigidBody.isKinematic = false;
		ballRigidBody.GetComponent<Collider2D>().enabled = true;
		this.transform.SetParent(null);
		ballRigidBody.velocity = releaseVelocity * 2;
	}

	void CapMaxSpeed(){
		if(ballRigidBody.velocity.x > maxSpeed){
			ballRigidBody.velocity = new Vector2(maxSpeed, ballRigidBody.velocity.y);
		}
		else if(ballRigidBody.velocity.x < -maxSpeed){
			ballRigidBody.velocity = new Vector2(-maxSpeed, ballRigidBody.velocity.y);
		}

		if(ballRigidBody.velocity.y > maxSpeed){
			ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, maxSpeed);
		}
		else if(ballRigidBody.velocity.y < -maxSpeed){
			ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -maxSpeed);
		}
	}
}
