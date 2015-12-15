using UnityEngine;
using System.Collections;

public class VirusFactory : MonoBehaviour {
	public GameObject redVirus;
	public GameObject yellowVirus;
	public GameObject blueVirus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Object getBlueVirus(Vector2 position) {
		return Instantiate(blueVirus, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public Object getRedVirus(Vector2 position) {
		return Instantiate(redVirus, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public Object getYellowVirus(Vector2 position) {
		return Instantiate(yellowVirus, new Vector3(position.x, position.y), Quaternion.identity);
	}
}
