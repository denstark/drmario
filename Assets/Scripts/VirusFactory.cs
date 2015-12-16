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

	public GameObject getBlueVirus(Vector2 position) {
		return (GameObject)Instantiate(blueVirus, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public GameObject getRedVirus(Vector2 position) {
		return (GameObject)Instantiate(redVirus, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public GameObject getYellowVirus(Vector2 position) {
		return (GameObject)Instantiate(yellowVirus, new Vector3(position.x, position.y), Quaternion.identity);
	}
}
