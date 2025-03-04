using UnityEngine;

public class physicsGh : MonoBehaviour {
	private Rigidbody2D rb;
	private CapsuleCollider2D capsuleCollider;
	private float groundY = -4f;
	private bool isOnShelf = false;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		if (Input.GetMouseButtonUp(0)) {
			if (rb.gravityScale == 0 && !isOnShelf) {
				EnableGravity();
			}
		}

		if (transform.position.y <= groundY) {
			StopFalling();
		}

		
	}

	void EnableGravity() {
		if (rb != null) {
			rb.gravityScale = 2f;
		}
	}

	void StopFalling() {
		if (rb != null) {
			rb.gravityScale = 0f;
			rb.velocity = Vector2.zero;
			Vector3 currentPosition = transform.position;
			transform.position = new Vector3(currentPosition.x, groundY, currentPosition.z);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("shelf")) {
			transform.localScale -= new Vector3(0.008f, 0.008f, 0f);
			if (transform.localScale.x <= 0.25f || transform.localScale.y <= 0.25f) {
				transform.localScale = new Vector3(0.25f, 0.25f, 1f);
				isOnShelf = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		 if (other.CompareTag("shelf")) {
		 	transform.localScale = new Vector3(0.45f, 0.45f, 1f);
		 	isOnShelf = false;
		}
	}
}
