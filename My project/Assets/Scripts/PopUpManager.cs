using UnityEngine;
using TMPro;
using System.Collections;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance { get; private set; }
    public TMP_Text killPopupText;      // Assign in Inspector

    private Coroutine hideCoroutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // Optionally: DontDestroyOnLoad(gameObject);
        if (killPopupText != null)
            killPopupText.gameObject.SetActive(false);
    }

    public void ShowPopup(string text, float duration)
    {
        if (killPopupText == null)
        {
            Debug.LogWarning("KillPopupManager: killPopupText is not assigned.");
            return;
        }

        killPopupText.gameObject.SetActive(true);
        killPopupText.text = text;

        // restart hide timer
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);
        hideCoroutine = StartCoroutine(HideAfter(duration));
    }

    private IEnumerator HideAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (killPopupText != null)
            killPopupText.gameObject.SetActive(false);
        hideCoroutine = null;
    }
}
