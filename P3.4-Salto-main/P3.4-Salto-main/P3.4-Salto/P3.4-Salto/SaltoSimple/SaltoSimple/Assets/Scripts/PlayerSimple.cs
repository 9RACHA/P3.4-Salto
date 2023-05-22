using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
using Unity.Netcode.Components;

public class PlayerSimple : NetworkBehaviour {
    
    public float velocidadMovimiento = 4f;
    public float fuerzaSalto = 10f;
    private Rigidbody rb;
    private bool isGrounded = true;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (!isGrounded)
            return;
        if (!IsOwner)
            return;

        float movimientoHori = Input.GetAxis("Horizontal");
        float movimientoVerti = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHori, 0f, movimientoVerti) * velocidadMovimiento;
        rb.velocity = movimiento;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Suelo")) {
            isGrounded = true;
        }
    }
}
