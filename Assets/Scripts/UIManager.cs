using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	#region Singleton class: UIManager

	public static UIManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	[Header ("Level Progress UI")]
	//sceneOffset: because you may add other scenes like (Main menu, ...)
	[SerializeField] int sceneOffset;
	[SerializeField] TMP_Text nextLevelText;
	[SerializeField] TMP_Text currentLevelText;
	[SerializeField] Image progressFillImage;

	void Start ()
	{
		//reset progress value

		SetLevelProgressText ();
	}

	void SetLevelProgressText ()
	{
		int level = SceneManager.GetActiveScene ().buildIndex + sceneOffset;
		currentLevelText.text = level.ToString ();
		nextLevelText.text = (level + 1).ToString ();
	}

	public void UpdateLevelProgress ()
	{
		float val = 1f - ((float)Level.Instance.objectsInScene / Level.Instance.totalObjects);
		progressFillImage.DOFillAmount (val, .4f);
	}
}
