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

    public GameObject getRandomPill(Vector2 position)
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                return getYellowPill(position);
            case 1:
                return getRedPill(position);            
            default:
                return getBluePill(position);
        }
    }
    public GameObject getRedPill(Vector2 position) {
		return (GameObject)Instantiate(redPill, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public GameObject getYellowPill(Vector2 position) {
		return (GameObject)Instantiate(yellowPill, new Vector3(position.x, position.y), Quaternion.identity);
	}

	public GameObject getBluePill(Vector2 position) {
		return (GameObject)Instantiate(bluePill, new Vector3(position.x, position.y), Quaternion.identity);
	}
}
