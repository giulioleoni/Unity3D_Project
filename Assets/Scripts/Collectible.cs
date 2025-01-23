using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioClip collectSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffect(collectSFX);
            GameManager.Instance.PickUpCollectible(this.gameObject);
        }
    }
}
