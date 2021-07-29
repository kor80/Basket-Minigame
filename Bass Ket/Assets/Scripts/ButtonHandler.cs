using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public void ConfirmNickname(InputField userInput)
    {
        if(userInput.text.Length < 1)
        {
            Debug.Log("Insert a valid nickname please.");
            return;
        }

        GameManager.Instance.SetUserNickname(userInput.text);
        SceneLoader.Instance.LoadGameScene();
    }

    public void PlayGame()
    {
        if(GameManager.Instance.UserNickname != null)
        {
            SceneLoader.Instance.LoadGameScene();
            Debug.Log(1);
        }
        else
        {
            foreach(Fade goFade in FindObjectsOfType<Fade>())
                goFade.StartFading();
        }
    }
}
