using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public VirusFactory virusFactory;
	public GameObject redPill;
	public PillSegmentFactory pillSegmentFactory;

	private float interval = 0.3f;
	private float nextMove = 0;
	private int lastDir = 0;
	private int gridSize = 8;
	private float tickInterval = 1.0f;
	private int screenHeight = 16;
	private int screenWidth = 8;
	private Vector2 pillOrigin = new Vector2(-28,44);

  // can't fit any more than this (given 8 x 16 with top 3 empty)
  private int maxVirusCount = 104;

	// Use this for initialization
	void Start() {
    LevelBuilder builder = new LevelBuilder();
    VirusLocation[] locs = builder.populateViruses(28, screenWidth, screenHeight);

    foreach (VirusLocation loc in locs) {
      Vector2 pos = getGridPosition(loc.x, loc.y);

      switch (loc.color) {
        case "yellow":
          virusFactory.getYellowVirus(pos);
          break;
        case "blue":
          virusFactory.getRedVirus(pos);
          break;
        case "red":
          virusFactory.getBlueVirus(pos);
          break;
      }
    }

		redPill = (GameObject)pillSegmentFactory.getRedPill(pillOrigin);
		InvokeRepeating("gameTick", 1, tickInterval);
	}
	
	// Update is called once per frame
	void Update() {
		handleMovement();
	}

	void handleMovement() {
		int dir = 0;

		if (Input.GetKey(KeyCode.LeftArrow)) {
			dir = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			dir = 1;
		}

		if (dir != 0 && (Time.time >= nextMove || dir != lastDir)) {
			Vector3 snapH = (Vector3.right * gridSize);
			redPill.transform.position = redPill.transform.position + (snapH * dir);
			nextMove = Time.time + interval;

			redPill.transform.position = clampedWidth(redPill.transform.position);
		}

		lastDir = dir;	
	}

	void gameTick() {
		Vector3 snapDown = (Vector3.down * gridSize);
		redPill.transform.position = redPill.transform.position + snapDown;
		if (redPill.transform.position.y <= screenBottom()) {
			redPill.transform.position = (Vector3)pillOrigin;
		}

	}

	Vector3 clampedWidth(Vector3 pos) {
		return new Vector3(Mathf.Clamp(pos.x, pillOrigin.x, (pillOrigin.x + (gridSize * (screenWidth - 1)))), pos.y);
	}

	float screenBottom() {
		return pillOrigin.y - (gridSize * screenHeight);
	}

	Vector2 getGridPosition(int w, int h) {
		return new Vector2((gridSize * w) + pillOrigin.x, pillOrigin.y - (h * gridSize));
	}
}
