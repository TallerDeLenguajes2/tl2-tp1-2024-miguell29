# Taller de Lenguajes 2 - TP1 - Miguel Juárez
### 2.a A partir del siguiente diseño de clases incompleto, responda las preguntas planteadas a continuación en el archivo Readme.md:

![Diseño de clases](/Resources/Diseño%20de%20clases.png)

* ¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
* ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
* Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados.
* ¿Cómo diseñaría los constructores de cada una de las clases?
* ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?

### **Respuestas:**
***
**Relaciones de Composición**
* El cliente forma **forma parte de** un pedido.

**Relaciones de Agregación**

* La clase cadete **Tiene uno o más** pedidos.
* La clase cadetería **Tiene uno o más** cadetes.
*** 

**Métodos de la clase Cadete**
* `AgregarPedido(Pedido pedido)`: Agrega un pedido a la lista de pedidos.
* `EliminarPedido(Pedido pedido)`: Elimina un pedido de la lista

**Métodos de la clase Cadetería**
* `AgregarCadete(Cadete cadete)`: Agrega un cadete a la lista de cadetes.
* `EliminarCadete(Cadete cadete)`: Elimina un cadete de la lista
* `MostrarInforme()`: muestra el monto ganado y la cantidad de envios por cadete.
***
**Atributos, propiedades y métodos públicos y privados**

**clase Cliente**

* **Atributos y propiedades privados:** nombre, direccion, telefono, datosReferencia.
* **Atributos y propiedades públicas:** Nombre, Direccion, Telefono, DatosReferencias (todos deberian ser getters)

**Clase Pedidos**
* **Atributos y propiedades privados:** nro, obs, cliente, estado.
* **Atributos y propiedades públicas:** Nro, Obs, Estado.
* **Métodos publicos:** VerDireccionCliente, VerDatosCliente.

**Clase Cadete**
* **Atributos y propiedades privados:** id, nombre, direccion, telefono, listadoPedidos
* **Atributos y propiedades públicas:** Id, Nombre, Direccion, Telefono, ListadoPedidos
* **Métodos publicos:** JornalACobrar.
* **Métodos privados:** AgregarPedido, EliminarPedido.

**Clase Cadeteria**
* **Atributos y propiedades privados:** nombre, telefono, listadoCadetes.
* **Atributos y propiedades públicas:** Nombre, Telefono, ListadoCadetes.
* **Métodos publicos:** MostrarInforme
* **Métodos privados:** AgregarCadete, EliminarCadete.
***

**Constructores**
* **Clase Cliente:** `Cliente(string nombre, string direccion, int telefono string datosReferenciaDireccion)`
* **Clase Pedidos:** `Pedido(int nro, string obs, Estado estado)`
* **Clase Cadete:** `Cadete(int id, string nombre, string direccion, int telefono)`
* **Clase Cadeteria:** `Cadeteria(string nombre, string telefono)`