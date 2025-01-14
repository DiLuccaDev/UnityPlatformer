using UnityEngine;

public class MoveObjectsOnUpdate : MonoBehaviour {
    
    [SerializeField] private GameObject UpdateCube; 
    [SerializeField] private GameObject FixedUpdateSphere;
    [SerializeField] private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"deltaUpdate: {Time.deltaTime}");
        UpdateCube.transform.position = UpdateCube.transform.position+=Vector3.right*(speed*Time.deltaTime);
    }
    
    void FixedUpdate()
    {
        Debug.Log($"deltaFixedUpdate: {Time.deltaTime}");
        FixedUpdateSphere.transform.position = FixedUpdateSphere.transform.position+=Vector3.right*(speed*Time.fixedDeltaTime);
    }
}