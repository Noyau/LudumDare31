using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{

	public float movementSpeed = 1.5f;
	private Vector3 targetPosition;

	void Start ()
	{
		this.targetPosition = transform.localPosition;
	}

	void Update ()
	{
		Vector3 currentPosition = transform.localPosition;
		float distanceToTarget = Vector3.Distance ( currentPosition, this.targetPosition );

		if ( distanceToTarget > 0.0f )
		{
			float step = movementSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards ( currentPosition, this.targetPosition, step );
		}
	}

	public void MoveToTarget ( Vector3 target )
	{
		this.targetPosition = target;
	}

}
