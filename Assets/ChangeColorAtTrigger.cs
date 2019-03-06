using UnityEngine;

public class ChangeColorAtTrigger : MonoBehaviour
{
    public Renderer rend;
    public Color OriginalColor;
    public VRTK.VRTK_ControllerEvents events; //kan genom att ha publika variabler dra in script som ligger på samma objekt så att de kan påkallas från detta scriptet

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (this.gameObject.GetComponent<Renderer>().materials.Length > 0)
        {
            OriginalColor = 
            this.gameObject.GetComponent<Renderer>().materials[0].color;
        }
        events = (VRTK.VRTK_ControllerEvents)FindObjectOfType(typeof(VRTK.VRTK_ControllerEvents));
    }

    // Update is called once per frame
    void Update()
    {
        if (events.AnyButtonPressed()) //kollar om det finns någon knapp som trycks ned - gör istället en event listener för det
        {
            rend.material.color = Color.white; //Ska trigga VRTK-scriptet
        }
        else
        {
            rend.material.color = OriginalColor;
        }
        //if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    rend.material.color = Color.white;
        //}
        //else
        //{
        //    rend.material.color = OriginalColor;
        //}
    }
}
