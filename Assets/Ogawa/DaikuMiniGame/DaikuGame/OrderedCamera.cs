using UnityEngine;

public class OrderedCamera : MonoBehaviour
{
    
     void Awake()
    {
        var camera = GetComponent<Camera>();
        camera.transparencySortMode = TransparencySortMode.CustomAxis;
        camera.transparencySortAxis = new Vector3(0.0F, 1.0F, 0.0F);
    }
}