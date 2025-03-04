using UnityEngine;

public class moveGh : MonoBehaviour {
	private float moveSpeed = 0.01f;
	private float minX = -1f, maxX = 24f;
	private float minY = -4f, maxY = 4f;
	private float cameraFollowSpeed = 3f;

	private bool isDragging = false;
	private Vector2 lastMousePosition;
	private Collider2D characterCollider;

	void Start() {
		characterCollider = GetComponent<Collider2D>();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (characterCollider != null && characterCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
				isDragging = true;
				lastMousePosition = Input.mousePosition;
			}
		}
		else if (Input.GetMouseButtonUp(0)) {
			isDragging = false;
		}

		if (isDragging) {
			Vector2 currentMousePosition = Input.mousePosition;
			Vector2 deltaPosition = (currentMousePosition - lastMousePosition) * moveSpeed;
			Vector3 newPosition = transform.position + new Vector3(deltaPosition.x, deltaPosition.y, 0);
			newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
			newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
			transform.position = newPosition;
			lastMousePosition = currentMousePosition;
		}

		if (Camera.main != null) {
			if (isDragging) {
				float clampedX = Mathf.Clamp(transform.position.x, 0f, 23f);
				Vector3 targetPosition = new Vector3(clampedX, Camera.main.transform.position.y, Camera.main.transform.position.z);
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * cameraFollowSpeed);
			}
		}
	}
}

