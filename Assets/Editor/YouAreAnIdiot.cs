using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class YouAreAnIdiot : EditorWindow {
	static Texture2D texture1;
	static Texture2D texture2;

	System.DateTime first;

	Vector2 pos;
	Vector2 diff = new Vector2 (6f, 6f);
	static Vector2 bound = new Vector2 (1440, 900);

	[MenuItem ("CustomMenu/you are an idiot %y")]
	public static void CreateWindow () {
		if (texture1 == null) {
			texture1 = (Texture2D) EditorGUIUtility.Load ("youareanidiot-0.png");
		}
		if (texture2 == null) {
			texture2 = (Texture2D) EditorGUIUtility.Load ("youareanidiot-1.png");
		}
		var window = CreateInstance<YouAreAnIdiot> ();
		window.ShowUtility ();
	}

	[MenuItem ("CustomMenu/Delete %e")]
	public static void DeleteWindow () {
		var sceneViews = Resources.FindObjectsOfTypeAll<YouAreAnIdiot> ();
		foreach (var view in sceneViews) {
			view.Close ();
		}
	}

	AudioSource source;

	void Awake () {
		source = GetAudioSource ();
		source.loop = true;
		source.Play ();

		this.minSize = new Vector2 (480, 360);
		this.maxSize = new Vector2 (480, 360);
		this.maximized = false;
		first = System.DateTime.Now;

		pos = new Vector2 (Random.Range (0, bound.x - minSize.x), Random.Range (40, bound.y - minSize.y));
		if (Random.Range (0, 2) == 0) diff *= new Vector2 (-1, 1);
		if (Random.Range (0, 2) == 0) diff *= new Vector2 (1, -1);
		this.position = new Rect (pos, this.minSize);
		first = System.DateTime.Now;
	}

	bool flag = false;

	void Update () {
		if (pos.x < 0 || pos.x + position.size.x > bound.x) {
			diff *= new Vector2 (-1, 1);
		}
		if (pos.y < 40 || pos.y + position.size.y > bound.y) {
			diff *= new Vector2 (1, -1);
		}
		pos += diff;
		position = new Rect (pos, position.size);

		var now = System.DateTime.Now;
		var timediff = (now - first).TotalMilliseconds;
		bool nowflag = (timediff % 800) >= 400;

		if (flag != nowflag) {
			flag = nowflag;
			Repaint ();
		}
	}

	void OnDisable () {
		source.Stop ();
	}

	void OnGUI () {
		GUI.DrawTexture (new Rect (0, 0, 480, 360), flag?texture1 : texture2);
	}

	static AudioSource GetAudioSource () {
		var gameObject =
			EditorUtility.CreateGameObjectWithHideFlags ("HideAudioSourceObject",
				HideFlags.HideAndDontSave, typeof (AudioSource));

		var hideAudioSource = gameObject.GetComponent<AudioSource> ();

		hideAudioSource.clip = (AudioClip) EditorGUIUtility.Load ("youareanidiot.mp3");

		return hideAudioSource;
	}
}
