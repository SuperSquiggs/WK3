using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility // This is a modified version of the Standard Assets script. The old namespace has been kept.
{
    public class DragThrowRigidbody : MonoBehaviour
    {
        const float k_Spring = 50.0f;
        const float k_Damper = 5.0f;
        const float k_Drag = 10.0f;
        const float k_AngularDrag = 5.0f;
        const float k_Distance = 0.2f;
        const bool k_AttachToCenterOfMass = false;

        const float k_minDistance = 1f;
        public float k_launchPower = 2f;

        private SpringJoint m_SpringJoint;
        private float oldDrag = 1f;
        private float oldAngularDrag = 1f;


        private void Update()
        {

            // Make sure the user pressed the mouse down
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            var mainCamera = FindCamera();

            // We need to actually hit an object
            RaycastHit hit = new RaycastHit();
            if (
                !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                                 mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                                 Physics.DefaultRaycastLayers))
            {
                return;
            }
            // We need to hit a rigidbody that is not kinematic
            if (!hit.rigidbody || hit.rigidbody.isKinematic)
            {
                return;
            }

            if (!m_SpringJoint)
            {
                var go = new GameObject("Rigidbody dragger");
                Rigidbody body = go.AddComponent<Rigidbody>();
                m_SpringJoint = go.AddComponent<SpringJoint>();
                body.isKinematic = true;
            }

            m_SpringJoint.transform.position = hit.point;
            m_SpringJoint.anchor = Vector3.zero;

            m_SpringJoint.spring = k_Spring;
            m_SpringJoint.damper = k_Damper;
            m_SpringJoint.maxDistance = k_Distance;
            m_SpringJoint.connectedBody = hit.rigidbody;
            oldDrag = m_SpringJoint.connectedBody.drag;
            oldAngularDrag = m_SpringJoint.connectedBody.angularDrag;
            StartCoroutine("DragThrowObject", hit.distance);
        }

        private IEnumerator DragThrowObject(float distance)
        {
            if (distance < k_minDistance)
            {
                distance = k_minDistance;
            }
            m_SpringJoint.connectedBody.drag = k_Drag;
            m_SpringJoint.connectedBody.angularDrag = k_AngularDrag;
            var mainCamera = FindCamera();

            while (Input.GetMouseButton(0))
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                m_SpringJoint.transform.position = ray.GetPoint(distance);

                if (Input.GetMouseButton(1)) // Throw code. We simply add an impulse force to the object, set its drag back to normal, disconnect it from the spring joint, and stop the coroutine.
                {
                    Vector3 throwPower = new Vector3(k_launchPower, k_launchPower, k_launchPower);
                    m_SpringJoint.connectedBody.AddForce(Vector3.Scale(ray.direction, throwPower), ForceMode.Impulse);
                    ReleaseDraggedBody();
                    yield break;
                }
                    yield return null;
            }
            if (m_SpringJoint.connectedBody)
            {
                ReleaseDraggedBody();
            }
        }

        private void ReleaseDraggedBody() 
        {
            m_SpringJoint.connectedBody.drag = oldDrag;
            m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
            m_SpringJoint.connectedBody = null;
        }

        private Camera FindCamera()
        {
            if (GetComponent<Camera>())
            {
                return GetComponent<Camera>();
            }

            return Camera.main;
        }
    }
}
