using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Text countText;
    public Text goBack;
    private int count;
    public Animator door;

    private void Start()
    {
        count = 0;
        SetCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Items: " + count.ToString() + "/3";
        if(count >= 3)
        {
            door.SetBool("Open", true);
            goBack.gameObject.SetActive(true);
        }
    }
}
