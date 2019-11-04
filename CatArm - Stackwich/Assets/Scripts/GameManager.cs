using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event System.Action OnCubeSpawned = delegate { };

    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;
	public PauseMenuScript someScriptHolder;



	public int missCount;
	public GameObject loseScreen;




	private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
		missCount = 0;
    }

    private void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{
			if (someScriptHolder.gameIsPaused == false)
			{
				if (MovingCube.CurrentCube != null)
				{
					MovingCube.CurrentCube.Stop();
					
				}

				if (missCount >= 3)
				{
					//LastCube = null;
					//CurrentCube = null;

					//SceneManager.LoadScene(0);

					loseScreen.SetActive(true);
				}
				else
				{
					spawnerIndex = spawnerIndex == 0 ? 1 : 0;
					currentSpawner = spawners[spawnerIndex];

					currentSpawner.SpawnCube();
					OnCubeSpawned();
				}
				//Test For Placement Zones
				/*
				
				get ingredient object
				reference PlacementZoneCheck.difference
				if (difference <= perf)
				{
					
					run snap function
					
				}
				else if (difference >= miss)
				{
					missCount++;
				}
				else
				{

				}
				
				
				 
				*/
			}
		}
    }




}
