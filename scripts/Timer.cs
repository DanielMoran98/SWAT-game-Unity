using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	// Update is called once per frame
	public float fElapsedTime;
	private int iTime;

	private void Start(){
		GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}", 120 / 60, 120 % 60);
	}

	void Update (){
		fElapsedTime -= Time.deltaTime;
		iTime = Mathf.RoundToInt(fElapsedTime);
		GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}", iTime / 60, iTime % 60);
		if (iTime <= 0){
			SceneManager.LoadScene(0);
		}
	}
}
