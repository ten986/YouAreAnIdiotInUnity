using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Sound.LoadSe ("dicision","decision22");	
		Sound.LoadSe ("clearrec", "people_people-stadium-cheer1");
		Sound.LoadSe ("clear", "people_people-stadium-applause1");
		Sound.LoadSe ("exit", "cancel5");
		Sound.LoadSe ("attack", "whip-attack-2");
		Sound.LoadSe ("hit", "kick-middle1");
		Sound.LoadSe ("erase1", "attack1");
		Sound.LoadSe ("erase2", "striking");
		Sound.LoadSe ("erase3", "damage7");
		Sound.LoadSe ("erase4", "damage6");
		Sound.LoadSe ("erase5", "iron-plate2");
		Sound.LoadSe ("erase6", "breaking_a glass");
		Sound.LoadSe ("erase7", "explosion1");
		Sound.LoadSe ("start", "gong-played1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
