using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Text countText;
    public Text goBack;
    private int count;
    public Animator door;
    public AudioSource CoinPickUp;
    public Camera cam;
    public Text camSize;
    private bool triggered = false;
    private float camSizeUpgrade;

    private void Start()
    {
        count = 0;
        SetCountText();
    }

    private void Update()
    {
        camSize.text = "Field of View: " + cam.orthographicSize.ToString("F0");
        if(triggered)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSizeUpgrade, Time.deltaTime * 2);

            if (cam.orthographicSize > camSizeUpgrade)
            {
                triggered = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            CoinPickUp.Play();
            triggered = true;
            camSizeUpgrade = cam.orthographicSize + 1;
            Destroy(other.gameObject);
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
