// LoadingScreenManager
// --------------------------------
// built by Martin Nerurkar (http://www.martin.nerurkar.de)
// for Nowhere Prophet (http://www.noprophet.com)
//
// Licensed under GNU General Public License v3.0
// http://www.gnu.org/licenses/gpl-3.0.txt

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;

public class LoadingScreenManager : MonoBehaviour
{

	[Header ("Loading Visuals")]
	public Image loadingIcon;
	public Text loadingDoneText;
	public Text loadingText;
	public Image progressBar;
	public Image fadeOverlay;
	public Text hintText;
	public Animator loadingAnimator;

	[Header ("Timing Settings")]
	public float waitOnLoadEnd = 0.25f;
	public float fadeDuration = 0.25f;

	[Header ("Loading Settings")]
	public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
	public ThreadPriority loadThreadPriority;

	[Header ("Other")]
	// If loading additive, link to the cameras audio listener, to avoid multiple active audio listeners
	public AudioListener audioListener;

	AsyncOperation operation;
	Scene currentScene;

	private string[] hints;
	private int hintsNumber = 0;

	public static int sceneToLoad = 3;
	// IMPORTANT! This is the build index of your loading scene. You need to change this to match your actual scene index
	//static int loadingSceneIndex = 2;

	public static void LoadScene (int levelNum)
	{				
		Application.backgroundLoadingPriority = ThreadPriority.High;
		//sceneToLoad = levelNum;
		SceneManager.LoadScene (sceneToLoad);
	}

	void Start ()
	{
		if (sceneToLoad < 0)
			return;
		

		fadeOverlay.gameObject.SetActive (true); // Making sure it's on so that we can crossfade Alpha
		currentScene = SceneManager.GetActiveScene ();
		StartCoroutine (LoadAsync (sceneToLoad));
	}

	private IEnumerator LoadAsync (int levelNum)
	{
		ShowLoadingVisuals ();

		yield return null; 

		FadeIn ();
		StartOperation (levelNum);

		float lastProgress = 0f;
		Loadhints ();

		// operation does not auto-activate scene, so it's stuck at 0.9
		while (DoneLoading () == false) {
			yield return null;



			if (Mathf.Approximately (operation.progress, lastProgress) == false) {
				progressBar.fillAmount = operation.progress;
				lastProgress = operation.progress;
			}
		}

		if (loadSceneMode == LoadSceneMode.Additive)
			audioListener.enabled = false;

		ShowCompletionVisuals ();

		yield return new WaitForSeconds (waitOnLoadEnd);

		FadeOut ();

		yield return new WaitForSeconds (fadeDuration);

		if (loadSceneMode == LoadSceneMode.Additive)
			SceneManager.UnloadScene (currentScene.name);
		else
			operation.allowSceneActivation = true;
	}

	private void StartOperation (int levelNum)
	{
		Application.backgroundLoadingPriority = loadThreadPriority;
		operation = SceneManager.LoadSceneAsync (levelNum, loadSceneMode);


		if (loadSceneMode == LoadSceneMode.Single)
			operation.allowSceneActivation = false;
	}

	private bool DoneLoading ()
	{
		return (loadSceneMode == LoadSceneMode.Additive && operation.isDone) || (loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f); 
	}

	void FadeIn ()
	{
		fadeOverlay.CrossFadeAlpha (0, fadeDuration, true);
	}

	void FadeOut ()
	{
		fadeOverlay.CrossFadeAlpha (1, fadeDuration, true);
	}

	void ShowLoadingVisuals ()
	{
		loadingIcon.gameObject.SetActive (true);
		loadingDoneText.gameObject.SetActive (false);

		progressBar.fillAmount = 0f;
		loadingText.text = "LOADING...";
	}

	void ShowCompletionVisuals ()
	{
		
		loadingAnimator.SetTrigger ("FadeOutTransition");
		loadingDoneText.gameObject.SetActive (true);
		loadingIcon.gameObject.SetActive (false);


		progressBar.fillAmount = 1f;
		loadingText.text = "LOADING DONE";
	}

	private void Loadhints ()
	{
		
		TextAsset hintsFile = Resources.Load<TextAsset> ("hints.txt");
		hints = hintsFile.text.Split ('\n');
		System.Random rd = new System.Random ();
		int random = rd.Next (0, hints.Length);
		hintText.text = hints [random];

	}

}