using UnityEngine;
using System.Collections;

public class InteractiveElementScript : MonoBehaviour
{

	public string caption;
	public float captionTimeout = 3.0f;

	private CursorScript cursor = null;
	private Rect labelRect = new Rect ( 0, 0, 100, 100 );
	private bool showCaption = false;
	private float lastCaption;

	void Start ()
	{
		this.lastCaption = -this.captionTimeout;
	}

	void Awake ()
	{
		this.cursor = CursorScript.GetSingleton ();
	}

	void OnTriggerStay2D ()
	{
		if ( !cursor.particles.isPlaying )
		{
			cursor.particles.Play ();
		}

		if ( Input.GetMouseButtonDown ( 0 ) )
		{
			this.showCaption = true;
			this.lastCaption = Time.time;
		}
	}

	void OnGUI ()
	{
		if ( this.showCaption || ( Time.time - this.lastCaption ) < this.captionTimeout )
		{
			GUI.Label ( this.labelRect, this.caption);
			this.showCaption = false;
		}
	}

}
