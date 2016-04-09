using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour {

	public Button fullbodyButton;
	public Button bodyPartButton;

	public GameObject bodyUIPrefab;
	public GameObject bodyPartUIPrefab;

	public GameObject NetworkObject;

	private NetworkSetup networkScript;

	private int bodyPartTestValue = 0;
	private int bodyFullTestValue = -1;

	void Start()
	{
		if (NetworkObject != null)
		{
			networkScript = NetworkObject.GetComponent<NetworkSetup> ();
		}
		else
		{
			Debug.LogError ("You haven't assigned NetworkObject!!");
		}
	}

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
		GameObject newUI = Instantiate<GameObject> (bodyUIPrefab);
		newUI.transform.SetParent (transform.parent);
		newUI.GetComponent<RectTransform> ().offsetMin = new Vector2 (0, 0);
		newUI.GetComponent<RectTransform> ().offsetMax = new Vector2 (0, 0);
		Destroy (gameObject);
	}

	private void OnBodyPartClicked()
	{
		GameObject newUI = Instantiate<GameObject> (bodyPartUIPrefab);
		newUI.transform.SetParent (transform.parent);
		newUI.GetComponent<RectTransform> ().offsetMin = new Vector2 (0, 0);
		newUI.GetComponent<RectTransform> ().offsetMax = new Vector2 (0, 0);
		Destroy (gameObject);
	}
}
