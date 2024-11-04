using UnityEngine;
using Unity.Netcode;

public class BoatVisual : NetworkBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite movingSprite;

    public NetworkVariable<bool> IsMoving;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsOwner) return;
        IsMoving.Value = playerController.Velocity > Mathf.Epsilon;
    }

    void LateUpdate()
    {
        spriteRenderer.sprite = IsMoving.Value ? movingSprite : idleSprite;
    }
}