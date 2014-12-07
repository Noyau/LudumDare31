using UnityEngine;
using System.Collections;

[ RequireComponent (typeof ( AudioSource ) ) ]
public class SoundScript : MonoBehaviour
{

	public float defaultVolume = 0.25f;
	public float volumeFadeRatio = 0.01f;
	public AudioClip[] soundEffects;

	private AudioSource source;
	private int nextSound;
	private float minDelay = 0.3f;
	private float maxDelay = 1.0f;
	private float lastDelay;
	private float lastPlay;
	private bool lastSoundEnded;

	void Start ()
	{
		this.nextSound = Random.Range ( 0, this.soundEffects.Length );
		this.lastDelay = 0.0f;
		this.lastPlay  = 0.0f;
		this.lastSoundEnded = true;
	}

	void Awake ()
	{
		if ( soundEffects.Length < 1)
			throw new System.Exception ( "How could you play any sound without clip(s) ?");

		this.source = GetComponent < AudioSource > ();
	}

	void Update ()
	{
		if ( this.lastSoundEnded )
		{
			this.source.Stop ();
			this.lastPlay = Time.time;
			this.lastSoundEnded = false;
		}

		if ( !this.source.isPlaying && ( Time.time - this.lastPlay ) > this.lastDelay )
		{
			if ( soundEffects.Length < 1)
				throw new System.Exception ( "How could you play any sound without clip(s) ?");

			this.lastDelay = Random.Range ( minDelay, maxDelay );

			this.source.volume = defaultVolume;
			this.source.clip = this.soundEffects [ this.nextSound ];
			this.source.PlayDelayed ( this.lastDelay );

			this.nextSound = Random.Range ( 0, this.soundEffects.Length );
		}

		if ( this.source.isPlaying )
			SoundFadeOut ();
	}

	/// Sound Fading
	private void SoundFadeOut ()
	{
		if ( this.source.volume > this.volumeFadeRatio )
			this.source.volume -= this.volumeFadeRatio * Time.deltaTime;
		else
			this.lastSoundEnded = true;
	}

}
