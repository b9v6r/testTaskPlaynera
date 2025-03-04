using UnityEngine;

public class setFrameRate : MonoBehaviour {

	public int frameRate = 60;
	public int vSync = 0;
	
	void Start() {
		Application.targetFrameRate = frameRate;
		QualitySettings.vSyncCount = vSync;
	}
}
