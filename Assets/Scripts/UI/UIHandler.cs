using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public GameInfo GameInfo;

    public GameObject ChooseCharacterMenu;

    public GameObject TurnInfoPanel;
    public TextMeshProUGUI TurnInfoText;

    public void SetLocalPlayerUI()
    {
        setLocalPlayerTurnInfo();
    }

    public void SetRemotePlayerUI()
    {
        setRemotePlayerTurnInfo();
    }

    public void ShowChooseCharacterUI()
    {
        var animator = ChooseCharacterMenu.GetComponent<Animator>();
        animator.SetTrigger("Show");
    }

    public void HideChooseCharacterUI()
    {
        var animator = ChooseCharacterMenu.GetComponent<Animator>();
        animator.SetTrigger("Hide");
    }

    private void setLocalPlayerTurnInfo()
    {
        var characterType = this.GameInfo.PlayerOne.PlayerType;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(characterType.Name);
        sb.Append("'s Turn (You)");
        this.TurnInfoText.text = sb.ToString();
        sb.Clear();

        TurnInfoPanel.GetComponent<Image>().color = characterType.UIColor;
    }

    private void setRemotePlayerTurnInfo()
    {
        var characterType = this.GameInfo.PlayerTwo.PlayerType;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(characterType.Name);
        sb.Append("'s Turn (Opponent)");
        this.TurnInfoText.text = sb.ToString();
        sb.Clear();

        TurnInfoPanel.GetComponent<Image>().color = characterType.UIColor;
    }

}
