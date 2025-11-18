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
            Email = addressInputField.text,
            Password = passwordInputField.text,
            Username = nameInputField.text,
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
        Debug.Log(registerPlayFabUserResult.Username);
    }

    public void Failure(PlayFabError playFabError)
    {
        PanelManager.Instance.Load(Panel.Error, playFabError.GenerateErrorReport());
    }
}
