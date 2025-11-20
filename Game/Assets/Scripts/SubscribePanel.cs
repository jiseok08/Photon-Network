using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class SubscribePanel : MonoBehaviour
{
    [SerializeField] InputField nameInputField;
    [SerializeField] InputField addressInputField;
    [SerializeField] InputField passwordInputField;

    public void Subscribe()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = nameInputField.text,
            Email = addressInputField.text,
            Password = passwordInputField.text
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );
    }

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        gameObject.SetActive(false);
    }

    public void Failure(PlayFabError playFabError)
    {
        var report = playFabError.GenerateErrorReport();
        var lines = report.Split("\n");

        PanelManager.Instance.Load(Panel.Error, $"{lines[2]}\n{lines[3]}");
    }
}
