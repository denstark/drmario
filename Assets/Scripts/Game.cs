using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Color { Red, Yellow, Blue };

public struct CellOccupant
{
    public Color color;
    public GameObject item;
}

public class Game : MonoBehaviour {

	public VirusFactory virusFactory;
	private GameObject currentPill;
	public PillSegmentFactory pillSegmentFactory;

	private float interval = 0.3f;
	private float nextMove = 0;
	private int lastDir = 0;
	private int gridSize = 8;
	private float tickInterval = 1.0f;
	private int screenHeight = 16;
	private int screenWidth = 8;
	private Vector2 pillOrigin = new Vector2(-28,44);
    Dictionary<string, CellOccupant> board = new Dictionary<string, CellOccupant>();
    // can't fit any more than this (given 8 x 16 with top 3 empty)
    private int maxVirusCount = 104;

	// Use this for initialization
	void Start() {
        
        LevelBuilder builder = new LevelBuilder();
        VirusLocation[] locs = builder.populateViruses(104, screenWidth, screenHeight);

        foreach (VirusLocation loc in locs)
        {
            Vector2 pos = getGridPosition(loc.x, loc.y);
            CellOccupant cellOccupant = new CellOccupant();
            switch (loc.color)
            {
                case "yellow":
                    cellOccupant.item = virusFactory.getYellowVirus(pos);
                    cellOccupant.color = Color.Yellow;
                    break;
                case "blue":
                    cellOccupant.item = virusFactory.getRedVirus(pos);
                    cellOccupant.color = Color.Blue;
                    break;
                case "red":
                    cellOccupant.item = virusFactory.getBlueVirus(pos);
                    cellOccupant.color = Color.Red;
                    break;
            }
            board.Add(loc.x.ToString() + ',' +  loc.y.ToString(), cellOccupant);
        }

        if (board.ContainsKey("5,12"))
        {
            Debug.Log("Exists");
        }

        currentPill = pillSegmentFactory.getRandomPill(pillOrigin);
		InvokeRepeating("gameTick", 1, tickInterval);
	}
	
	// Update is called once per frame
	void Update() {
		handleMovement();
	}

	void handleMovement() {
		int dir = 0;

		if (Input.GetKey(KeyCode.LeftArrow)) 
        {
			dir = -1;
		} 
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
			dir = 1;
		}

		if (dir != 0 && (Time.time >= nextMove || dir != lastDir)) 
        {
            Vector3 lastPos = currentPill.transform.position;
			Vector3 snapH = (Vector3.right * gridSize);
			currentPill.transform.position = currentPill.transform.position + (snapH * dir);
			nextMove = Time.time + interval;

            if (currentPill.transform.position.x > screenRight() || currentPill.transform.position.x < screenLeft())
            {
                currentPill.transform.position = lastPos;
            }
		}

		lastDir = dir;	
	}

	void gameTick() {
        Vector3 lastPos = currentPill.transform.position;
		Vector3 snapDown = (Vector3.down * gridSize);
		currentPill.transform.position = currentPill.transform.position + snapDown;

		if (currentPill.transform.position.y < screenBottom()) 
        {
            currentPill.transform.position = lastPos;
            currentPill = pillSegmentFactory.getRandomPill(pillOrigin);
		}

	}

    float screenRight()
    {
        return pillOrigin.x + (gridSize * (screenWidth - 1));
    }

    float screenLeft()
    {
        return pillOrigin.x;
    }

	float screenBottom() {
		return pillOrigin.y - (gridSize * (screenHeight - 1));
	}

	Vector2 getGridPosition(int w, int h) {
		return new Vector2((gridSize * w) + pillOrigin.x, pillOrigin.y - (h * gridSize));
	}
}
