using UnityEngine;

public class ChangeColorAtTrigger : MonoBehaviour
{
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger triggered.");
            rend.material.color = Color.white;
        }
    }
}
