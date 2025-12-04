using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Panel
{ 
    Error,
    Subscribe,
    Generator,
    Pause
}

public class PanelManager : MonoBehaviour
{
    GameObject clone = null;

    static Dictionary<Panel, GameObject> dictionry = new();

    static PanelManager instance;

    public static PanelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Load(Panel panel, string message)
    {
        if (dictionry.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

            clone.name = clone.name.Replace("(Clone)", "");

            dictionry.Add(panel, clone);
        }
        else
        {
            clone = dictionry[panel];

            clone.SetActive(true);
        }

        if (clone.GetComponent<ErrorPanel>() == true)
        {
            clone.GetComponent<ErrorPanel>().SetText(message);
        }
    }
}
