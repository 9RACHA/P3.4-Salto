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
        // Obtiene el componente Rigidbody adjunto al objeto
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        // Si el jugador no está en el suelo, no realiza ninguna acción
        if (!isGrounded)
            return;
        // Si el jugador no es el propietario del objeto de red, no realiza ninguna acción
        if (!IsOwner)
            return;
        // Obtener la entrada del teclado para el movimiento horizontal y vertical
        float movimientoHori = Input.GetAxis("Horizontal");
        float movimientoVerti = Input.GetAxis("Vertical");
        // Calcula el vector de movimiento en función de la entrada del teclado y la velocidad de movimiento
        Vector3 movimiento = new Vector3(movimientoHori, 0f, movimientoVerti) * velocidadMovimiento;
        // Aplica el movimiento al Rigidbody del jugador
        rb.velocity = movimiento;
        // Si se presiona la tecla de espacio y el jugador está en el suelo, aplica una fuerza hacia arriba para simular un salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // Si el jugador colisiona con un objeto etiquetado como "Suelo", se considera que está en el suelo
        if (collision.gameObject.CompareTag("Suelo")) {
            isGrounded = true;
        }
    }
}
