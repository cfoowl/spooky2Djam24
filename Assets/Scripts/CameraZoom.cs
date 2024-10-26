using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public static CameraZoom instance;
    public Camera mainCamera;
    public float zoomSpeed = 2f; // Vitesse de zoom
    public float limitZoom = 1f;

    private Vector3 originalPosition;
    private float originalSizeOrFOV;


    void Awake() {
        instance = this;
    }

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        originalPosition = mainCamera.transform.position;
        originalSizeOrFOV = mainCamera.orthographic ? mainCamera.orthographicSize : mainCamera.fieldOfView;
    }

    public bool ZoomToPoint(Vector3 targetPosition)
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, zoomSpeed * Time.deltaTime);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, limitZoom, zoomSpeed * Time.deltaTime);
        if (mainCamera.orthographicSize > limitZoom+0.1f) {
            return true;
        } else {
            return false;
        }
    }

    public IEnumerator startZoom(Vector3 targetPosition) {
        while (ZoomToPoint(targetPosition)) {
            yield return new WaitForFixedUpdate();
        }
    }


    public void ResetZoom()
    {
        StopAllCoroutines();
        // Revenir aux valeurs originales
        mainCamera.transform.position = originalPosition;
        
        if (mainCamera.orthographic)
            mainCamera.orthographicSize = originalSizeOrFOV;
        else
            mainCamera.fieldOfView = originalSizeOrFOV;
    }
}
