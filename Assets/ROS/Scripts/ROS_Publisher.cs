using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using RosMessageTypes.Geometry;
using RosMessageTypes.Sensor;
using RosMessageTypes.Nav;

public class ROS_Publisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/pos_rot";

    // Instantiate ROS messages to be published
    RosMessageTypes.Geometry.TwistMsg twist;

    // The game object
    public GameObject cube;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 3f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<RosMessageTypes.Geometry.TwistMsg>(topicName); //just an example

        // Create a new message to populate
        twist = new RosMessageTypes.Geometry.TwistMsg();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            cube.transform.rotation = Random.rotation;

            twist = new RosMessageTypes.Geometry.TwistMsg();

            // Populate the message as you see fit

            // Finally send the message to server_endpoint.py running in ROS
            ros.Publish(topicName, twist);

            timeElapsed = 0;
        }
    }
};
