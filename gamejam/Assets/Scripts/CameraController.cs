using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public PlayerController player;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

        // The transform of the position of the object attached to this script
        // The camera won't jump with the player
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = player.transform.position;
	}
}
