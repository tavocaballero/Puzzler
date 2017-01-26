using UnityEngine;
using System.Collections;

public class lightUp : MonoBehaviour {
	public Material lightUpMaterial;
	public GameObject GameLogic;
	private Material defaultMaterial;

	// Use this for initialization
	void Start () {
		defaultMaterial = this.GetComponent<MeshRenderer> ().material; //Save our initial material as the default
		ParticleSystem ps = this.GetComponentInChildren<ParticleSystem>();
		ps.Stop();//Start without emitting particles
		GameLogic = GameObject.Find ("GameLogic");
	}

	// Update is called once per frame
	void Update () {

	}
	public void patternLightUp(float duration) { //The lightup behavior when displaying the pattern
		StartCoroutine(lightFor(duration));
	}


	public void gazeLightUp() {
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		ParticleSystem ps = this.GetComponentInChildren<ParticleSystem>();
		ps.Play();//Start emitting particles


	}
	public void playerSelection() {
		GameLogic.GetComponent<GameLogic>().playerSelection(this.gameObject);
		this.GetComponent<GvrAudioSource>().Play();
	}
	public void aestheticReset() {
		this.GetComponent<MeshRenderer>().material = defaultMaterial; //Revert to the default material
		ParticleSystem ps = this.GetComponentInChildren<ParticleSystem>();
		ps.Stop();//Stop emitting particles

	}

	public void patternLightUp() { //Lightup behavior when the pattern shows.
		this.GetComponent<MeshRenderer>().material = lightUpMaterial; //Assign the hover material
		ParticleSystem ps = this.GetComponentInChildren<ParticleSystem>();
		ps.Play();//Start emitting particles
		this.GetComponent<GvrAudioSource> ().Play (); //Play the audio attached
	}


	IEnumerator lightFor(float duration) { //Light us up for a duration.  Used during the pattern display
		patternLightUp ();
		yield return new WaitForSeconds(duration-.1f);
		aestheticReset ();
	}
}