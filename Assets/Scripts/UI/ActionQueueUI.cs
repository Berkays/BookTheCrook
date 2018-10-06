using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionQueueUI : MonoBehaviour
{
    public GameObject ActionPrefab;

    public RectTransform ContentWindow;
    public TextMeshProUGUI LastActionText;
    public Transform Container;

    private ActionController actionController;

    public void ShowActions()
    {
        //Get action controller
        if (actionController == null)
            actionController = FindObjectOfType<ActionController>();

        var actionSet = actionController.GetActions();

        if (actionSet.Count == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);

            LastActionText.text = "Last Action: " + actionSet[0].ToString();

            removeChilds();

            if (actionSet.Count == 1)
            {
                Show();
                return;
            }

            for (int i = 1; i < actionSet.Count; i++)
            {
                var obj = GameObject.Instantiate(ActionPrefab, Container);

                var textComponent = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

                textComponent.text = "Action: " + actionSet[i].ToString();
            }
        }
    }

    public void Show()
    {
        ContentWindow.anchoredPosition = new Vector2(0, ContentWindow.sizeDelta.y);
    }

    public void Hide()
    {
        ContentWindow.anchoredPosition = new Vector2(0, 75);
    }

    //TODO Pool objects
    private void removeChilds()
    {
        int childCount = Container.childCount;
        for (int i = 0; i < childCount; i++)
            Destroy(Container.GetChild(i).gameObject);
    }
}
