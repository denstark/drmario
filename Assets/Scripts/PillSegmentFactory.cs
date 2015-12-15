using UnityEngine;
using System.Collections;

public class PillSegmentFactory : MonoBehaviour {

	public GameObject redPill;
	public GameObject yellowPill;
	public GameObject bluePill;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Object getRedPill(Vector2 position) {
		return Instantiate(redPill, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public Object getYellowPill(Vector2 position) {
		return Instantiate(yellowPill, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public Object getBluePill(Vector2 position) {
		return Instantiate(bluePill, new Vector3(position.x, position.y), Quaternion.identity);
	}
}
