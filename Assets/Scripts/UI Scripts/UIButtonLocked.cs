using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButtonLocked : MonoBehaviour
{
    public Transform image = null;

    // Use this for initialization
    public void locked(bool active)
    {
        this.GetComponent<Button>().interactable = !active;
        image.gameObject.SetActive(active);
    }
}
