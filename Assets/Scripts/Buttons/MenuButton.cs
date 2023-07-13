using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Option option;
    private void OnMouseDown()
    {
        switch (option)
        {
            case Option.Casual:
                StartCasual();
                break;
            case Option.Competitive:
                //TODO: Implement competitive mode
                break;
            case Option.Back:
                GoBack();
                break;
            case Option.Quit:
                Application.Quit();
                break;
        }
    }

    private void StartCasual()
    {
        SceneManager.LoadScene("Casual");
    }

    private void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
