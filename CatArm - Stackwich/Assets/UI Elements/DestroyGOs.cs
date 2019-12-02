using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGOs : MonoBehaviour
{


	//public GameObject targetOne;
	//public GameObject targetTwo;
	//public GameObject targetThree;


	public void DestroyUISet(GameObject targetOne, GameObject targetTwo, GameObject targetThree)
	{
		Destroy(targetOne);
		Destroy(targetTwo);
		Destroy(targetThree);
	}









}
