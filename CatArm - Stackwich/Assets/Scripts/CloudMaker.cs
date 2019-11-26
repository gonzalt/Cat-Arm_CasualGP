using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaker : MonoBehaviour
{

	public float cloudSpawnRate = 5.0f;

	public Rigidbody cloudPrefab;


	void Start()
    {
		InvokeRepeating("SpawnACloud", 0.0f, cloudSpawnRate);
	}

    





    void Update()
    {
        
    }





	void SpawnACloud()
	{
		Rigidbody instance = Instantiate(cloudPrefab);

		//instance.velocity = Random.insideUnitSphere * 5;
	}







}
