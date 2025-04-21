using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour
{
    public void ChooseGame1()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseGame2()
    {
        SceneManager.LoadScene(2);
    }

    public void ChooseGame3()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
