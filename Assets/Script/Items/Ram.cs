using UnityEngine;

public class Ram : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& collision.gameObject.GetComponent<PlayerHack>().GetDevice() != null)
        {
            GameObject device = collision.gameObject.GetComponent<PlayerHack>().GetDevice();
            device.GetComponent<Devices>().GetRamItem();
            Destroy(gameObject);
        }
    }
}
