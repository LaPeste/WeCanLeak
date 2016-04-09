using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour {

	public Button fullbodyButton;
	public Button bodyPartButton;

	public GameObject bodyUIPrefab;
	public GameObject bodyPartUIPrefab;

	private void OnEnable()
	{
		fullbodyButton.onClick.AddListener (OnFullBodyClicked);
		bodyPartButton.onClick.AddListener (OnBodyPartClicked);
	}

	private void OnDisable()
	{
		fullbodyButton.onClick.RemoveListener (OnFullBodyClicked);
		bodyPartButton.onClick.RemoveListener (OnBodyPartClicked);
	}

	private void OnFullBodyClicked()
	{
		Instantiate (bodyUIPrefab);
		Destroy (gameObject);
	}

	private void OnBodyPartClicked()
	{
		Instantiate (bodyUIPrefab);
		Destroy (bodyPartUIPrefab);
	}
}
