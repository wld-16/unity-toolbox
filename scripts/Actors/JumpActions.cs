using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JumpActions : MonoBehaviour
{
    public Rigidbody rb;
    public List<GameObject> landingPoints;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Jump(float jumpingForce, bool isKinematic)
    {
        if (isKinematic)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            rb.velocity = Vector3.up * jumpingForce;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            rb.AddForce(Vector3.up * jumpingForce);
        }
    }

    public void JumpByCurveToRandomLandingPoint(AnimationCurve curve, float force, float timeElapsed, float offset, float endTime)
    {
        GameObject landingPoint = landingPoints[Random.Range(0, landingPoints.Count)];
        Vector3 vector3 = landingPoint.transform.position;
        Vector2 landingPoint2d = new Vector2(vector3.x, vector3.z);
        StartCoroutine(JumpByCurveCoroutine(curve, force, timeElapsed, offset, landingPoint2d, endTime));
    }


    public void Stabilize()
    {
        transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles,
            new Vector3(0, transform.rotation.eulerAngles.y, 0), 1));
    }

    IEnumerator JumpByCurveCoroutine(AnimationCurve curve, float force, float timeElapsed, float offset, Vector2 target,
        float endTime)
    {
        float startTime = Time.time;
        float journeyLength = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), target);
        while (timeElapsed < endTime)
        {
            float distCovered = (Time.time - startTime) * force;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.

            Vector2 addForce = Vector2.Lerp(
                new Vector2(target.x - transform.position.x, target.y - transform.position.z), Vector2.zero,
                fractionOfJourney);

            Debug.DrawRay(transform.position,
                new Vector3(addForce.x * force, 0, addForce.y * force), Color.cyan);

            transform.Translate(new Vector3(addForce.x * force, 0f, addForce.y * force),
                Space.World);
            transform.position = new Vector3(transform.position.x, curve.Evaluate(timeElapsed) + offset, transform.position.z);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }
}
