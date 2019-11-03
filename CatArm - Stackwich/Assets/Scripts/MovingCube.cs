using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get; set; }

	public GameObject referenceGO;
	public GameManager gameManagerScript;

	[SerializeField]
    private float moveSpeed = 1f;




	private void OnEnable()
    {
		referenceGO = GameObject.Find("Start");
		gameManagerScript = referenceGO.GetComponent<GameManager>();

        if (LastCube == null)
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>();

        CurrentCube = this;
        GetComponent<Renderer>().material.color = GetRandomColor();

		//Changes Scale of Spawned Cube?
		transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);
		//transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = GetHangover();

        //float max = MoveDirection == MoveDirection.z ? LastCube.transform.localScale.z : LastCube.transform.localScale.x;
		float max = 0.5f;
		if (Mathf.Abs(hangover) >= max)
        {
            //LastCube = null;
            //CurrentCube = null;


			
			gameManagerScript.missCount++;


			if (gameManagerScript.missCount >= 3)
			{
				LastCube = null;
				CurrentCube = null;

				SceneManager.LoadScene(0);
			}
			

			//Load Main Menu
			//SceneManager.LoadScene(0);
		}
		else
		{
			//LastCube = this;
		}

        float direction = hangover > 0 ? 1f : -1f;

		/*
        if (MoveDirection == MoveDirection.z)
            SplitCubeOnZ(hangover, direction);
        else
            SplitCubeOnX(hangover, direction);
			*/
        LastCube = this;
    }

    private float GetHangover()
    {
        if (MoveDirection == MoveDirection.z)
            return transform.position.z - LastCube.transform.position.z;
        else
            return transform.position.x - LastCube.transform.position.x;

    }

    private void SplitCubeOnX(float hangover, float direction)
    {
        float newXSize = LastCube.transform.localScale.x - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.x - newXSize;

        float newXPosition = LastCube.transform.position.x + (hangover / 2);
        transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        float cubeEdge = transform.position.x + (newXSize / 2f * direction);
        float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2f * direction;

		//Spawn Overhang Cube
        //SpawnDropCube(fallingBlockXPosition, fallingBlockSize);
    }

    private void SplitCubeOnZ(float hangover, float direction)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = LastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2f * direction);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f * direction;

		//Spawn Overhang Cube
        //SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
    }

    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if (MoveDirection == MoveDirection.z)
        {
            cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPosition);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize, transform.localScale.y, transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockZPosition, transform.position.y, transform.position.z);
        }
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

        Destroy(cube.gameObject, 1f);
    }

    private void Update()
    {
        if(MoveDirection == MoveDirection.z)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        else
            transform.position += transform.right * Time.deltaTime * moveSpeed;
    }
}
