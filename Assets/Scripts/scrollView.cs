using UnityEngine;

public class scrollView : MonoBehaviour {
	private float scrollSpeed = 0.01f;
	private float minX = 0f;
	private float maxX = 23f;
	public Camera scrollCamera;
	private bool isDragging = false;
	private Vector2 lastMousePosition;
	public Collider2D ghCollider;

	void Update() {
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonDown(0)) {
			if (ghCollider == null || !ghCollider.OverlapPoint(mouseWorldPos)) {
				isDragging = true;
				lastMousePosition = Input.mousePosition;
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			isDragging = false;
		}

		if (isDragging && Input.GetMouseButton(0) && scrollCamera != null) {
			Vector2 currentMousePosition = Input.mousePosition;
			Vector2 deltaPosition = (currentMousePosition - lastMousePosition) * scrollSpeed;
			float newX = Mathf.Clamp(scrollCamera.transform.position.x + deltaPosition.x, minX, maxX);
			scrollCamera.transform.position = new Vector3(newX, scrollCamera.transform.position.y, scrollCamera.transform.position.z);
			lastMousePosition = currentMousePosition;
		}
	}

}

