using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

	public float movespeed = 1.0f;
	public Vector3 cloudDirection;// = (1.0f, 0f, 0f);

	private float directionMultiplierOne = 1.0f;

	public Vector3 startPos;

	public GameObject cloudsList;
	public int cloudChoice;

	private Vector3 tempChange;

	public GameObject cameraObj;
	public GameObject BGObj;

	public float scaleRangeMin = 0.5f;
	public float scaleRangeMax = 1.5f;



	private void OnEnable()
	{

		cloudsList = GameObject.Find("CloudHolder");
		cloudChoice = UnityEngine.Random.Range(0, 11);

		this.gameObject.GetComponent<SpriteRenderer>().sprite = cloudsList.transform.GetChild(cloudChoice).gameObject.GetComponent<SpriteRenderer>().sprite;
		//this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

		tempChange = new Vector3 (this.gameObject.transform.localScale.x * UnityEngine.Random.Range(scaleRangeMin, scaleRangeMax), this.gameObject.transform.localScale.y * UnityEngine.Random.Range(scaleRangeMin, scaleRangeMax), this.gameObject.transform.localScale.z * UnityEngine.Random.Range(scaleRangeMin, scaleRangeMax));
		this.gameObject.transform.localScale = tempChange;

		cameraObj = GameObject.Find("CameraForSandwich");
		BGObj = cameraObj.gameObject.transform.GetChild(0).gameObject;

		this.gameObject.transform.rotation = cameraObj.gameObject.transform.rotation;

		this.gameObject.transform.position = cameraObj.gameObject.transform.position + BGObj.gameObject.transform.position;

		tempChange = this.gameObject.transform.position;

		/*
		startPos.x = tempChange.x + (UnityEngine.Random.Range(-1.0f, 1.0f));
		tempChange.x = startPos.x;
		startPos.y = tempChange.y + (UnityEngine.Random.Range(-1.0f, 1.0f));
		tempChange.y = startPos.y;

		this.gameObject.transform.position = tempChange;
		*/
		startPos.x = cameraObj.gameObject.transform.position.x - 6.76f;
		startPos.y = cameraObj.gameObject.transform.position.y - 3.86f;
		startPos.z = cameraObj.gameObject.transform.position.z - 6.74f;

		if (UnityEngine.Random.value < 0.5f)
		{
			
		}
		else
		{
			
		}




		this.gameObject.transform.position = startPos;


		cloudDirection.x = 1.0f;
		cloudDirection.y = 0.0f;
		cloudDirection.z = 0.0f;

		if (UnityEngine.Random.value < 0.5f)
		{
			directionMultiplierOne = 1.0f;
			cloudDirection = transform.right;
			startPos.x = startPos.x + 1.5f;
			startPos.z = startPos.z - 1.5f;
		}
		else
		{
			directionMultiplierOne = -1.0f;
			cloudDirection = (transform.right * -1);
			startPos.x = startPos.x - 1.5f;
			startPos.z = startPos.z + 1.5f;
		}

		startPos.y = startPos.y + UnityEngine.Random.Range(-2.3f, 4.3f);

		this.gameObject.transform.position = startPos;



		cloudDirection = (UnityEngine.Random.Range(.5f, 1.0f) * cloudDirection);

	}



	void Start()
    {

		/*
		cloudDirection = cloudDirection * directionMultiplierOne;

		cloudDirection.x = (UnityEngine.Random.Range(.5f, 1.0f) * cloudDirection.x);//, cloudDirection.y, cloudDirection.z);

		*/


		//startPos.x = (UnityEngine.Random.Range(0.5f, 1.0f) * startPos.x);

		//startPos.y = (UnityEngine.Random.Range(-225.0f, 225.0f));
		//startPos.z = 0.0f;

	}



	void Update()
    {
        
		this.gameObject.transform.position += cloudDirection * Time.deltaTime;





	}



}
