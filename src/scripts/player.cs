using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Color color;
	public float runVelocity;
	public float jumpVelocity;
	public float dashVelocity;
	public float maxSpeed;

	private Rigidbody2D playerRigidbody;
	// Use this for initialization
	void Start () {
		playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
			//playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
		}
		playerRigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * runVelocity, 0, 0));

		if(Input.GetKey(KeyCode.DownArrow)){
			playerRigidbody.AddForce(new Vector3(0, -dashVelocity, 0));
		}

		else if(Input.GetKeyDown(KeyCode.Space)){
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
			playerRigidbody.AddForce(new Vector3(0, jumpVelocity, 0));
		}

		CapMaxSpeed();
	}

	void CapMaxSpeed(){
		if(playerRigidbody.velocity.x > maxSpeed){
			playerRigidbody.velocity = new Vector2(maxSpeed, playerRigidbody.velocity.y);
		}
		else if(playerRigidbody.velocity.x < -maxSpeed){
			playerRigidbody.velocity = new Vector2(-maxSpeed, playerRigidbody.velocity.y);
		}
	}
}
