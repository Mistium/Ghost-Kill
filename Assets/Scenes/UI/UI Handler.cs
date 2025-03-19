using UnityEngine;
using UnityEngine.UI;

public class QuestPopupController : MonoBehaviour
{
    public GameObject questPopup;
    public Button questsButton;

    private void Start()
    {
        if (questPopup != null) questPopup.SetActive(false);

        if (questsButton != null) questsButton.onClick.AddListener(ToggleQuestPopup);
        else Debug.LogError("Quests Button reference not set!");
    }

    public void ToggleQuestPopup()
    {
        if (questPopup != null) questPopup.SetActive(!questPopup.activeSelf);
    }
}