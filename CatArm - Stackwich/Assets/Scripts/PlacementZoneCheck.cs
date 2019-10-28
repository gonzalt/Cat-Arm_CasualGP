using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementZoneCheck : MonoBehaviour
{

	public Vector3 placementOfIng;
	public Vector3 centerLine;
	public float difference;

	public string currentPlacement;


	// Start is called before the first frame update
	void Start()
    {

		centerLine = GameObject.Find("Start").transform.position;
		currentPlacement = " ";

	}



    // Update is called once per frame
    void Update()
    {
        
    }



	public void placedIngredient()
	{

		placementOfIng = gameObject.transform.position;

		/*
		
		// check tag first

		if ( right ing )
		{

			difference = Math.Abs(centerLine.x - placementOfIng.x);

			if (difference <= .15f)
			{
				currentPlacement = "Perfect";
			}
			if (difference > .5f)
			{
				currentPlacement = "Miss";
			}
			else
			{
				currentPlacement = "Good";
			}
		}
		else if (left ing)
		{

			difference = Math.Abs(centerLine.z - placementOfIng.z);

			if (difference <= .15f)
			{
				currentPlacement = "Perfect";
			}
			if (difference > .5f)
			{
				currentPlacement = "Miss";
			}
			else
			{
				currentPlacement = "Good";
			}

		}

		//
		//Run SplatSound, PlayPlacementSFX Function
		//PlayPlacementSFX(currentPlacement);





		 */

	}

}
