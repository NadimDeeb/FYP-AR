using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using RosMessageTypes.Geometry;
using RosMessageTypes.Sensor;
using RosMessageTypes.Nav;
using MixedReality.Toolkit.UX;
using UnityEngine.UI;

public class ROS_Publisher : MonoBehaviour
{
    ROSConnection ros;
    // Robot movemnt variables
    private string MovementTopic = "/robot/cmd_vel";
    public MixedReality.Toolkit.UX.Slider VerticalSlider;
    public MixedReality.Toolkit.UX.Slider HorizontalSlider;

    // Instantiate ROS messages to be published
    RosMessageTypes.Geometry.TwistMsg robot_mov_twist;

    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 3f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        // start the ROS connection and create publishers
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<RosMessageTypes.Geometry.TwistMsg>(MovementTopic);

        // Create a new message to populate
        robot_mov_twist = new RosMessageTypes.Geometry.TwistMsg();
    }

    // Update is called once per frame
    void Update()
    {
        // Robot movement updates ----------------------------------------------------------------------------------------------------
        float horizontalValue = HorizontalSlider.Value;
        float verticalValue = VerticalSlider.Value;

        // Adjust the linear and angular velocities based on slider values
        float linearVelocity = verticalValue * 2.0f; // Adjust multiplier as needed
        float angularVelocity = horizontalValue * 2.0f; // Adjust multiplier as needed

        // Populate Twist message with linear and angular velocities
        robot_mov_twist.linear.x = linearVelocity;
        robot_mov_twist.angular.z = angularVelocity;

        // Publish the Twist message to ROS
        ros.Publish(MovementTopic, robot_mov_twist);

        // Debug information
        Debug.Log($"Linear Velocity: {linearVelocity}, Angular Velocity: {angularVelocity}");
        // ----------------------------------------------------------------------------------------------------------------------------
    }
};
