using UnityEngine.SceneManagement;
using UnityEngine;
public class ResetScene : MonoBehaviour
{
	public void OnButtonPress()
	{
		SceneManager.LoadScene(0);
	}
}

