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

	public GameObject assetsList;
	public int ingChoice;

	private bool recalculateNormals = false;
	private Vector3[] baseVertices;

	public GameObject soundGO;
	public SplatSound soundScript;

	[SerializeField]
	private float moveSpeed = 1f;



	private void OnEnable()
    {
		referenceGO = GameObject.Find("GameManager");
		gameManagerScript = referenceGO.GetComponent<GameManager>();

		soundGO = GameObject.Find("SoundManager");
		soundScript = soundGO.GetComponent<SplatSound>();

		assetsList = GameObject.Find("AssetsHolder");
		ingChoice = UnityEngine.Random.Range(0, 13);

		if (LastCube == null)
			LastCube = GameObject.Find("Start").GetComponent<MovingCube>();
		else
		{
			CurrentCube = this;
			GetComponent<Renderer>().material = assetsList.transform.GetChild(ingChoice).gameObject.GetComponent<Renderer>().material;
			GetComponent<MeshFilter>().mesh = assetsList.transform.GetChild(ingChoice).gameObject.GetComponent<MeshFilter>().mesh;


			if (baseVertices == null)
				baseVertices = GetComponent<MeshFilter>().mesh.vertices;

			var vertices = new Vector3[baseVertices.Length];

			for (var i = 0; i < vertices.Length; i++)
			{
				var vertex = baseVertices[i];
				vertex.x = vertex.x * 1;
				vertex.y = vertex.y * 10;
				vertex.z = vertex.z * 1;

				vertices[i] = vertex;
			}

			GetComponent<MeshFilter>().mesh.vertices = vertices;

			if (recalculateNormals)
			{
				GetComponent<MeshFilter>().mesh.RecalculateNormals();
				GetComponent<MeshFilter>().mesh.RecalculateBounds();
			}

		}
		//Changes Scale of Spawned Cube?
		//transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);
		//transform.localScale = new Vector3(x: 1f, y: 0.1f, z: 1f);
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = GetHangover();

		int assetNumber = ingChoice + 1;
		string placeType = " ";

		if ( assetNumber == 1 || assetNumber == 2 || assetNumber == 4 || assetNumber == 6 || assetNumber == 7 || assetNumber == 9 || assetNumber == 11)
		{
			placeType = "Good";
			//soundScript.PlayPlacementSFX("Perfect");

			if (Mathf.Abs(hangover) <= .15)
			{
				placeType = "Perfect";
				//this.transform.position.x = 0;
				float thisCubesYCoor = this.transform.position.y;
				transform.position = new Vector3(0, thisCubesYCoor, 0);

			}

		}
		if (assetNumber == 3 || assetNumber == 5 || assetNumber == 8 || assetNumber == 10 || assetNumber == 12 || assetNumber == 13)
		{
			placeType = "Inedible";
			//soundScript.PlayPlacementSFX("Perfect");
		}

		
		//float max = MoveDirection == MoveDirection.z ? LastCube.transform.localScale.z : LastCube.transform.localScale.x;
		float max = 0.5f;
		if (Mathf.Abs(hangover) >= max)
        {
			//LastCube = null;
			//CurrentCube = null;
			if (assetNumber == 1 || assetNumber == 2 || assetNumber == 4 || assetNumber == 6 || assetNumber == 7 || assetNumber == 9 || assetNumber == 11)
			{
				placeType = "Miss";

				//soundScript.PlayPlacementSFX("Perfect");

				gameManagerScript.missCount = gameManagerScript.missCount + 1;
				Debug.Log(gameManagerScript.missCount);
			}
			if (assetNumber == 3 || assetNumber == 5 || assetNumber == 8 || assetNumber == 10 || assetNumber == 12 || assetNumber == 13)
			{
				placeType = " ";
				//soundScript.PlayPlacementSFX("Perfect");
			}
			//Debug.Log(gameManagerScript.missCount);
			
			//gameManagerScript.missCount = gameManagerScript.missCount + 1;

			
			if (gameManagerScript.missCount >= 3)
			{
				LastCube = null;
				CurrentCube = null;

				//SceneManager.LoadScene(0);
			}
			

			//Load Main Menu
			//SceneManager.LoadScene(0);
		}
		else
		{
			if (assetNumber == 3 || assetNumber == 5 || assetNumber == 8 || assetNumber == 10 || assetNumber == 12 || assetNumber == 13)
			{
				gameManagerScript.missCount = gameManagerScript.missCount + 1;
				Debug.Log(gameManagerScript.missCount);

			}

			LastCube = this;
		}

		soundScript.PlayPlacementSFX(placeType);


		float direction = hangover > 0 ? 1f : -1f;

		/*
        if (MoveDirection == MoveDirection.z)
            SplitCubeOnZ(hangover, direction);
        else
            SplitCubeOnX(hangover, direction);
			*/
        //LastCube = this;
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
