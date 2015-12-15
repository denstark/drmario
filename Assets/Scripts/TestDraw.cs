using UnityEngine;
using System.Collections;

public class TestDraw : MonoBehaviour {

	public GameObject redVirus;
	public GameObject yellowVirus;
	public GameObject blueVirus;

	// Use this for initialization
	void Start () {

		Vector3 placeMarker = new Vector3(7,0);

		Instantiate(redVirus, Vector3.zero, Quaternion.identity);
		Instantiate(yellowVirus, placeMarker, Quaternion.identity);
		placeMarker.x = 14;

		Instantiate(blueVirus, placeMarker, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
