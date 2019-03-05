using UnityEngine;

public class ChangeColorAtTrigger : MonoBehaviour
{
    public Renderer rend;
    public Color OriginalColor;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (this.gameObject.GetComponent<Renderer>().materials.Length > 0)
        {
            OriginalColor = 
            this.gameObject.GetComponent<Renderer>().materials[0].color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            rend.material.color = Color.white;
        }
        else
        {
            rend.material.color = OriginalColor;
        }
    }
}
