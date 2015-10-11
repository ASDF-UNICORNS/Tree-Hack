using UnityEngine;
using System.Collections;

public class Garbage : MonoBehaviour
{

    public GameObject TrashCan;
    void Update()
    {
        print(TrashCan.transform.position.x + " " + TrashCan.transform.position.y);

        if ((TrashCan.transform.position.x <= transform.position.x + 1.6 &&
             TrashCan.transform.position.x >= transform.position.x - 1.6) &&
            (TrashCan.transform.position.y <= transform.position.y + 1.1 &&
             TrashCan.transform.position.y >= transform.position.y - 1.1))
            Destroy(gameObject);

    }
}
