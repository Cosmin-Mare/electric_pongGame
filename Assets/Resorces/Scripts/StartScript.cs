using UnityEngine;
using TMPro;

public class StartScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI StartText;
    [SerializeField] GameObject GameManager;

    void Start()
    {
        StartText.text = "3";
    }

    void Update()
    {
        Invoke("SetTwo", 1f);
        Invoke("SetOne", 2f);
        Invoke("EnableStartText", 3f);
        Invoke("DisableStartText", 4f);
    }

    void SetTwo() { StartText.text = "2"; }
    void SetOne() { StartText.text = "1"; }

    public void DisableStartText()
    {
        StartText.enabled = false;
        GameManager.gameObject.SetActive(true);
    }

    public void EnableStartText()
    {
        StartText.text = "GO!";
        StartText.fontSize = 100;
    }
}
