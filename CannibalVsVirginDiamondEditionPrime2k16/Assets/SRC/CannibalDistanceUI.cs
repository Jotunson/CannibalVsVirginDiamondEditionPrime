using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannibalDistanceUI : MonoBehaviour {

    Vector3 canToVir;
    Quaternion arrowRot;
    GameObject virgin;
    public GameObject cannibalIcon;
    public GameObject Arrow;
    Image cannibalImage;
    Image arrowImage;
    float maxIconDist;
    public float maxDist = 50f;
    float distance;

	// Use this for initialization
	void Start () {
        virgin = GameObject.Find("Virgin");
        cannibalIcon = GameObject.Find("CannibalIcon");
        Arrow = GameObject.Find("Arrow");
        cannibalImage = cannibalIcon.GetComponent<Image>();
        arrowImage = Arrow.GetComponent<Image>();
        maxIconDist = cannibalImage.rectTransform.anchoredPosition.y;

	}
	
	// Update is called once per frame
	void Update () {
        canToVir = virgin.transform.position - transform.position;
        distance = canToVir.magnitude;
        if(distance > maxDist)
        {
            distance = maxDist;
        }

        cannibalImage.rectTransform.anchoredPosition = new Vector2(0, ExtendedMath.RescaleValue(distance, -25, maxIconDist, 0, maxDist));

        if(transform.position.x <= virgin.transform.position.x)
        {
            arrowRot = Quaternion.Euler(0, 0, -Vector3.Angle(transform.forward, canToVir.normalized) * 1.2f);
        }
        else
        {
            arrowRot = Quaternion.Euler(0, 0, Vector3.Angle(transform.forward, canToVir.normalized) * 1.2f);
        }

        arrowImage.rectTransform.rotation = arrowRot;



        if(transform.position.z > virgin.transform.position.z - 5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, virgin.transform.position.z - 5);
        }
	}
}
