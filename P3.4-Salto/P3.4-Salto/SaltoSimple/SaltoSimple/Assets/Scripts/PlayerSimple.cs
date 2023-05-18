using Unity.Netcode;
using UnityEngine;

public class PlayerSimple : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    private Rigidbody rb;
    private bool isGrounded = true;
    private float fuerzaSalto = 5f;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            RequestInitialPositionServerRpc();
        }
    }

    [ServerRpc]
    void RequestInitialPositionServerRpc()
    {
        Position.Value = GetRandomPositionOnPlane();
        UpdatePositionClientRpc(Position.Value);
    }

    [ServerRpc]
    void RequestPositionChangeServerRpc(Vector3 direction)
    {
        if (isGrounded)
        {
            Position.Value += direction;
            UpdatePositionClientRpc(Position.Value);
        }
    }

    [ClientRpc]
    void UpdatePositionClientRpc(Vector3 newPosition)
    {
        if (!IsOwner)
            Position.Value = newPosition;
    }

    static Vector3 GetRandomPositionOnPlane()
    {
        return new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void Update()
    {
        if (IsOwner)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                direction = Vector3.right;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                direction = Vector3.back;
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                direction = Vector3.forward;

            if (direction != Vector3.zero)
                RequestPositionChangeServerRpc(direction);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                JumpServerRpc();
        }

        transform.position = Position.Value;
    }

    [ServerRpc]
    void JumpServerRpc()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * fuerzaSalto, ForceMode.Impulse);
        isGrounded = false;
        UpdatePositionClientRpc(transform.position);
    }
}
