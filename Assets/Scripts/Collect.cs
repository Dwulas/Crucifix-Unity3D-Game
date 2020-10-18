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

    private void Start()
    {
        count = 0;
        SetCountText();
    }

    private void Update()
    {
        camSize.text = "Field of View:" + cam.orthographicSize.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            CoinPickUp.Play();
            cam.orthographicSize += 1;
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
