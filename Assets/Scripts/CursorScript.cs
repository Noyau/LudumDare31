using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CircleCollider2D))]
public class CursorScript : MonoBehaviour
{

	private static CursorScript instance = null;

	public static CursorScript GetSingleton ()
 {
		if ( !instance )
		{
			instance = FindObjectOfType ( typeof ( CursorScript ) ) as CursorScript;

			if ( !instance )
				Debug.LogError ("You need a cursor in order to play the game");
		}

		return instance;
	}

	public GameObject lastPath;
	public ParticleSystem particles;
	private Vector3 pointerPosition;

	void Start ()
	{
		instance = this;
		Screen.showCursor = false;
		this.lastPath = null;
		this.pointerPosition = Vector3.zero;
		this.particles.Stop ();
	}

	void Update ()
	{
		CircleCollider2D cursorCollider = GetComponent < CircleCollider2D > ();
		Vector3 mousePosition = Input.mousePosition;
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint ( mousePosition );
		cursorPosition.z = 0.0f;

		this.pointerPosition = cursorPosition;
		this.pointerPosition.x += cursorCollider.center.x;
		this.pointerPosition.y += cursorCollider.center.y;

		if ( lastPath )
		{
			if ( !particles.isPlaying )
				particles.Play ();

			if ( Input.GetMouseButtonDown ( 0 ) )
				Debug.Log ("Holy Shit, It Works!");
		}
		else
			particles.Stop ();

		Vector3 cursorViewport = Camera.main.WorldToViewportPoint ( cursorPosition );

		if ( cursorViewport.x < 0.0f )
			cursorViewport.x = 0.0f;
		else if ( cursorViewport.x > 1.0f )
			cursorViewport.x = 1.0f;

		if ( cursorViewport.y < 0.0f )
			cursorViewport.y = 0.0f;
		else if ( cursorViewport.y > 1.0f )
			cursorViewport.y = 1.0f;

		cursorPosition = Camera.main.ViewportToWorldPoint ( cursorViewport );
		cursorPosition.x -= cursorCollider.center.x;
		cursorPosition.y -= cursorCollider.center.y;

		transform.localPosition = cursorPosition;
	}

}
