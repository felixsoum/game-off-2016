using UnityEngine;

public class WheelScript : GearTarget
{
    public float turnSpeed = 10000f;
    WheelJoint2D joint;
    Rigidbody2D myBody;

    void Awake()
    {
        joint = GetComponent<WheelJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
        Attach(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>());
    }

    public void Attach(Rigidbody2D mainBody)
    {
        joint.connectedBody = mainBody;
        Vector2 relativeToMainPosition = transform.position - joint.connectedBody.transform.position;
        joint.connectedAnchor = relativeToMainPosition;
    }

    public override void Turn(float direction)
    {
        base.Turn(direction);
        myBody.angularVelocity = -direction * turnSpeed * Time.deltaTime;
    }
}
