# P3.4 Movemento con Network transform e código eficiente

Crea un xogo multixogador no que os xogadores poidan moverse sobre o plano (arriba, abaixo, esquerda e dereita) e que poidan saltar (ou semellante). Faino usando o Network transform.

Fai que o código sexa o máis eficiente posible, sen partes que sobren, sen código redundante ou sen partes que non se usen nunca. Podes asumir que o código se vai executar sempre con Host e nunca con server.

Entregable:

O script ou scripts relevante

Un pequeno informe cun par de capturas que demostren que o xogo funciona e coas explicacións que consideres axeitadas

O enderezo de github que contén o proxecto


## Informe

Al principio cambié el script de Ejemplo llamado HelloWorlManager y lo renombré GameManager después eliminé los botones de Server ya que no lo usaremos. Tambien elimine los metodos encargados del cambio de posicion y de cambio de color ya que no es necesario para este ejercicio.

El HelloWorldPlayer del ejercicio de ejemplo pasara a llamarse PlayerSimple en un principio intente ir sacando codigo poco a poco minimizando funcionalidad pero finalmente opte por reescribirlo desde el principio. 

Al iniciar el proyecto:
Elimine el boton del server ya que no sera necesario
![image](https://github.com/9RACHA/P3.4-Salto/assets/66274956/ebcb03b7-abc9-45c2-a3fa-8ea321d62a58)

Al pulsar el boton Host:
![image](https://github.com/9RACHA/P3.4-Salto/assets/66274956/b2ba40ad-ed56-4e55-85eb-46a966662a9c)

El Player spawneado aparecerá en el centro de la escena, ya que se elimino la opcion de que se ubicara en un lugar aleatorio delimitado.
Salta y se mueve correctamente.

Al pulsar el cliente desde la build:
![image](https://github.com/9RACHA/P3.4-Salto/assets/66274956/f4df8dcd-b742-4030-b232-a892a04b5b21)
Si no hubo ningun input de movimiento de flechas o salto, esta sera la posicion por defecto, ya que el nuevo player cliente tambien aparecera en el centro de la escena

Muevo el player Cliente hacia la izquierda:
![image](https://github.com/9RACHA/P3.4-Salto/assets/66274956/c94eed73-5dce-455d-acbc-46382188f673)

Muevo el Player Host hacia la derecha:
![image](https://github.com/9RACHA/P3.4-Salto/assets/66274956/62eca46e-d7d9-49f6-a355-873bd24711d4)

![image](https://github.com/9RACHA/P3.4-Salto/assets/66274956/d88c8f10-bc5c-4b39-8fb6-c74dcf1ac8e2)
Al heredar de la clase NetworkTransform permite sincronizar objetos entre multiples clientes.

El metodo OnIsServerAuthoritative determina si el servidor o el cliente es responsable de actualizar la posicion del player.

Al devolver falso el cliente es responsable de actualizar la posicion.



