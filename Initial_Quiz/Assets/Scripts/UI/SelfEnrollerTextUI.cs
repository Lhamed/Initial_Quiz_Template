using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SelfEnrollerTextUI : MonoBehaviour
{
    public string Id;

    private void Awake()
    {
        UIHandler.Instance.EnrollUIComponent(gameObject.GetComponent<Text>(), Id);
    }
}

