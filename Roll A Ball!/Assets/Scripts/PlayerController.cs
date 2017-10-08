using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	public Text restartText;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		restartText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		CheckOutOfBounds ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			count++;
			other.gameObject.SetActive (false);
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 14) {
			winText.text = "YOU WON! HURRAH!";
		}
	}

	void CheckOutOfBounds()
	{
		if (rb.position.y <= -1) {
			restartText.text = "Press R to restart";
		}
	}
}
