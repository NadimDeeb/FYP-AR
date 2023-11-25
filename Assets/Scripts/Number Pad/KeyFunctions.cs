using MixedReality.Toolkit.UX;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    public string keyName;
    public GameObject mrtkActionButton; // Reference to the MRTK action button
    public NumberPadInput numberPadInput;

    private void OnValidate()
    {
        // You can add validation logic here if needed
    }

    void Start()
    {
        keyName = gameObject.name;
        // Assuming you set up your MRTK action button in the Unity Editor
        if (mrtkActionButton != null)
        {
            // Assuming you've set up the appropriate script to handle button clicks
            mrtkActionButton.GetComponent<PressableButton>().OnClicked.AddListener(OnClick);
        }
    }

    public void OnClick()
    {
        numberPadInput.OnKeyPressedEvent(keyName);
    }

    private void OnEnable()
    {
        if (mrtkActionButton != null)
        {
            //mrtkActionButton.GetComponent<PressableButton>().OnClicked.AddListener(OnClick);
        }
    }

    private void OnDisable()
    {
        if (mrtkActionButton != null)
        {
            mrtkActionButton.GetComponent<PressableButton>().OnClicked.RemoveListener(OnClick);
        }
    }
}
