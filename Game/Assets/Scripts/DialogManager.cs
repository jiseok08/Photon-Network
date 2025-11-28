using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] InputField inputField;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Chat();
        }
    }

    public void Chat()
    {


        if (inputField == null) { return; }

        Text message = Instantiate(Resources.Load<Text>("Talk"));

        message.text = inputField.text;

        inputField.text = null;
    }
}
