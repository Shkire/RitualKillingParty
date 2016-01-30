using UnityEngine;
using System.Collections;
using System;

public class ManageAudioClips : MonoBehaviour {

	[SerializeField]
	private AudioPar[] audioList;

	public void Play(int pos){
		if (pos < audioList.Length) {
			this.gameObject.GetComponent<AudioSource> ().outputAudioMixerGroup = audioList [pos].mixer;
			System.Random rnd = new System.Random (Guid.NewGuid().GetHashCode());
			int audioPlays = rnd.Next (0,audioList[pos].audios.Length);
			this.gameObject.GetComponent<AudioSource> ().clip = audioList [pos].audios [audioPlays].clip;
			float audioPitch =(float) (rnd.NextDouble()*(1+audioList [pos].audios [audioPlays].pitchVariation-(1-audioList [pos].audios [audioPlays].pitchVariation))+1-audioList [pos].audios [audioPlays].pitchVariation);
			this.gameObject.GetComponent<AudioSource> ().pitch = audioPitch;
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}


}
