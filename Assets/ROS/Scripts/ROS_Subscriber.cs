using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using RosMessageTypes.Geometry;
using RosMessageTypes.Sensor;
using RosMessageTypes.Nav;

public class ROS_Subscriber : MonoBehaviour
{
    RosMessageTypes.Geometry.TwistMsg twisty;
    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<RosMessageTypes.Geometry.TwistMsg>("/topic_name", twist_callback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void twist_callback(RosMessageTypes.Geometry.TwistMsg twist)
    {
        twisty = twist;
    }
}
