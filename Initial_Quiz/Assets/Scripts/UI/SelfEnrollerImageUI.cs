using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelfEnrollerImageUI : MonoBehaviour
{
    public string Id;

    private void Awake()
    {
        UIHandler.Instance.EnrollUIComponent(gameObject.GetComponent<Image>(), Id);
    }
}

