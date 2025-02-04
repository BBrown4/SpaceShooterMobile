using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;

    private void Awake()
    {
        var lastUnlockedLevel = PlayerPrefs.GetInt(EndGameManager.LEVEL_UNLOCK, firstLevelBuildIndex);
        for (var i = 0; i < lvlButtons.Length; i++)
        {
            var button = lvlButtons[i];
            if (i + firstLevelBuildIndex <= lastUnlockedLevel)
            {
                button.interactable = true;
                button.image.sprite = unlockedIcon;
                var text = button.GetComponentInChildren<TextMeshProUGUI>();
                text.text = $"{i + 1}";
                text.enabled = true;
            }
            else
            {
                button.interactable = false;
                button.image.sprite = lockedIcon;
                button.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }
}
