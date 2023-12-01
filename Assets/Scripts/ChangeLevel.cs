using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    private void GoToLevel(int number)
    {
        SceneManager.LoadScene(number);
    }

	private void Update()
	{
		GameObject.FindGameObjectsWithTag("Player");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}
}
