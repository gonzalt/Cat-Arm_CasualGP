using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementZoneCheck : MonoBehaviour
{

	public Vector3 placementOfIng;
	public Vector3 centerLine;
	public float difference;

	public 


	// Start is called before the first frame update
	void Start()
    {

		centerLine = GameObject.Find("Start").transform.position;


	}



    // Update is called once per frame
    void Update()
    {
        
    }



	public void placedIngredient()
	{

		placementOfIng = gameObject.transform.position;

		/*
		if ( right ing )
		{

			difference = Math.Abs(centerLine.x - placementOfIng.x);

		}
		else if (left ing)
		{

			difference = Math.Abs(centerLine.z - placementOfIng.z);

		}









		 */

	}

}
