using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour
{

	private GameObject cursor = null;

	void Awake ()
	{
		this.cursor = GameObject.FindWithTag ( "Cursor" );

		if ( !this.cursor )
			throw new System.Exception ( "How would you play a Point 'n' Click game without a cursor ?");
	}

	void Update ()
	{
		Vector3 cameraPosition = transform.localPosition;

		if ( cameraPosition.x < -2.97f )
			cameraPosition.x = -2.97f;
		else if ( cameraPosition.x > 2.97f )
			cameraPosition.x =  2.97f;

		if ( cameraPosition.y < -0.23f )
			cameraPosition.y = -0.23f;
		else if ( cameraPosition.y > 2.51f )
			cameraPosition.y =  2.51f;

		transform.localPosition = cameraPosition;
	}

}
