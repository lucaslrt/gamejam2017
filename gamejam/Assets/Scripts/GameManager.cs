﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Transform rockGenerator;
    private Vector3 rockStartPoint;

    public Transform trunkGenerator;
    private Vector3 trunkStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;
    private RockDestroyer[] rockList;
    private TrunkDestroyer[] trunkList;

    // Use this for initialization
    void Start () {
        platformStartPoint = platformGenerator.position;
        rockStartPoint = rockGenerator.position;
        trunkStartPoint = trunkGenerator.position;
        playerStartPoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        rockList = FindObjectsOfType<RockDestroyer>();
        trunkList = FindObjectsOfType<TrunkDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < rockList.Length; i++)
        {
            rockList[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < trunkList.Length; i++)
        {
            trunkList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        rockGenerator.position = rockStartPoint;
        trunkGenerator.position = trunkStartPoint;

        player.gameObject.SetActive(true);
    }

    
}
