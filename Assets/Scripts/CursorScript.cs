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

	public GameObject lastPath = null;
	public ParticleSystem particles;
	private PlayerControllerScript player = null;

	void Start ()
	{
		instance = this;
		Screen.showCursor = false;
		this.particles.Stop ();
	}

	void Awake ()
	{
		this.player = FindObjectOfType ( typeof ( PlayerControllerScript ) ) as PlayerControllerScript;

		if ( !this.player )
			throw new System.Exception ( "That's embarassing, their is no player" );
	}

	void Update ()
	{
		CircleCollider2D cursorCollider = GetComponent < CircleCollider2D > ();
		Vector3 mousePosition = Input.mousePosition;
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint ( mousePosition );
		cursorPosition.x += cursorCollider.center.x;
		cursorPosition.y += cursorCollider.center.y;
		cursorPosition.z = 0.0f;

		if ( lastPath )
		{
			if ( !particles.isPlaying )
				particles.Play ();

			if ( Input.GetMouseButtonDown ( 0 ) )
			{
				if ( lastPath.tag == "Zone" )
					Debug.Log ( "Waaarp ZaaaOooonne!" );
				else if ( lastPath.tag == "Ground" )
					player.MoveToTarget ( cursorPosition );
			}
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
