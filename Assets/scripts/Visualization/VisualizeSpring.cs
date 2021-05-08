using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VisualizeSpring : MonoBehaviour
{
    private Vector3 springOriginPosition;
    private Vector3 springEndPosition;

    private LineRenderer _lineRenderer;
    private SpringJoint _springJoint;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _springJoint = GetComponent<SpringJoint>();
        springOriginPosition = transform.position;
    }

    private void Update()
    {
        springOriginPosition = transform.TransformPoint(_springJoint.anchor);
        springEndPosition = _springJoint.connectedBody.transform.TransformPoint(_springJoint.connectedAnchor);

        _lineRenderer.SetPosition(0,springOriginPosition);
        _lineRenderer.SetPosition(1,springEndPosition);
    }
}
