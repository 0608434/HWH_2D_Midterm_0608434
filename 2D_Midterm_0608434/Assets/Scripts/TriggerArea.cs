using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject[] stones;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "碰到")
        {

            stones[0].SetActive(false);

        }

    }

}
