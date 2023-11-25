using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Robotics.ROSTCPConnector;

public class SetIPButtonText : MonoBehaviour
{
    bool checkedOnce;
    public TextMeshProUGUI buttonText; // Use TextMeshProUGUI for text display
    public ROSConnection ros;

    void Start()
    {
        UpdateButtonText();
        checkedOnce = false;
    }

    void Update()
    {
        if (!checkedOnce && ros.HasConnectionThread && !ros.HasConnectionError)
        {
            checkedOnce = true;
            ConnectSuccess();
        }
        else if (!checkedOnce && ros.HasConnectionError)
        {
            checkedOnce = false;
            ConnectFail();
        }
    }

    public void CheckConnectionStatus()
    {
        checkedOnce = false;
    }

    void UpdateButtonText()
    {
        buttonText.text = ros.RosIPAddress;
    }

    void ConnectFail()
    {
        UpdateButtonTextWithColor("<color=red>{0}</color>", ros.RosIPAddress);
    }

    void ConnectSuccess()
    {
        UpdateButtonTextWithColor("<color=green>{0}</color>", ros.RosIPAddress);
    }

    void UpdateButtonTextWithColor(string format, params object[] args)
    {
        buttonText.text = string.Format(format, args);
    }
}
