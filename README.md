### Caracteristicas

- Proyecto Desarrollado en .Net 6
- Se desarrollaron 2 aplicaciones, una API y una Aplicación web que la consume
- EL objetivo del proyecto es generar transacciones a partir de tarjetas de credito de los clientes, para poder generar reportes a partir de ello, calculando el monto de pago de contado, interes bonificable, pago minimo...
- La Api se desarrollo con las mejores practicas de desarrollo (SOLID), aplicando tambien AutoMapper, FluentValidation, CQRS, UnitOfWork, entre otros
- El Proyecto web fue desarrollado con las mejores practicas de desarrollo (SOLID)
- Se utilizo SQL Server para la base de datos, utilizando Procedimientos Almacenados para la interaccion con los datos

# Funcionamiento
- Se muestra la pantalla principal del cliente, en donde se muestran las tarjetas que tiene registradas
[![Portada](https://github.com/RobertBonilla/BancoTarjeta/blob/main/Documentacion/capturas/test/pantallaPrincipa%C3%B1.png "Portada")](https://github.com/RobertBonilla/BancoTarjeta/blob/main/Documentacion/capturas/test/pantallaPrincipa%C3%B1.png "Portada")

- Pantalla de compras, se selecicona la tarjeta y se le puede hacer un cargo
[![Compra](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/compra.png "Compra")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/compra.png "Compra")
- Pantalla de pago, se hace un abono a la tarjeta
[![Pago](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/pago.png "Pago")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/pago.png "Pago")

- Pantalla Estado de cuenta
[![EstadoCuenta](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/EstadoCuenta.png "EstadoCuenta")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/EstadoCuenta.png "EstadoCuenta")

- Aqui se encuentra toda la informacion de la tarjeta:
- disponible
- Limite
- Saldo
- Monto a pagar
- Monto con interes bonificable
- Monto minimo
- Interes bonificable,
- Tasa de Interes 
- Compras del mes actual
- Compras del mes pasado
- Detalle de Compras (registros)
- Detalle de Pagos (registros)
- Imprimir


  - Imprimir Estado de Cuenta, imprimiento Estado de Cuenta

[![PrintEC](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/PrintEstadoCuenta.png "PrintEC")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/PrintEstadoCuenta.png "PrintEC")

- Historial de transacciones del mes, con los cargos y abonos ordenados por fecha descendente
[![Historial](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/Historial.png "Historial")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/Historial.png "Historial")

- Imprimiendo Historial

  [![printHistorial](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/PrintHistorial.png "printHistorial")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/PrintHistorial.png "printHistorial")

### Arquitectura

## Base de Datos

- Diagrama de base de datos

[![Database](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/Database.png "Database")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/test/Database.png "Database")


- Funcion para obtener el ID de la tarjeta mediante su numero de tarjeta, se pudo validar mas, pero se hizo a modo de ejemplo

[![tarjetaId](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/getTarjetaId.png "tarjetaId")](http://https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/getTarjetaId.png "tarjetaId")

- Verificar Transaccion, para antes de ingresar un cargo, verificar que la tarjeta cuente con disponible necesario
  
[![VerificarTransaccion](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/verificarTransaccion.png "VerificarTransaccion")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/verificarTransaccion.png "VerificarTransaccion")

- Cargo Tarjeta, para validar el cargo utilizando las funciones anteriores
  
[![cargoTarjeta](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/cargoTarjeta.png "cargoTarjeta")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/cargoTarjeta.png "cargoTarjeta")

- Abono Tarjeta, para verificar el abono correcto

  [![AbonoTDC](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/abonoTarjeta.png "AbonoTDC")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/DB/abonoTarjeta.png "AbonoTDC")

  ## API Net 6

- Se desarrollo en capas, como se muestra acontinuación

[![APIAll](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_All.png "APIAll")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_All.png "APIAll")

- Aplicacion Principal, contiene los controladores y el archivo de configuracion principal, desde donde se realiza la injeccion de dependencias y los llamados a los servicios
  
  [![ApiBase](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/Arquitectura_API_base.png "ApiBase")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/Arquitectura_API_base.png "ApiBase")

- ApiCore, en esta capa se mueve la logica del negocio, se ejecutan los procesos importantes, se hace a travez de injeccion de dependencias
  
[![ApiCore](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/Arquitectura_API_Core.png "ApiCore")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/Arquitectura_API_Core.png "ApiCore")

- Domain, se almacenan los Dto y Entidades, que manejara principalmente la capa de infraestructura
- Destacar que en esta capa se incluyeron los Handlers, pertenecientes a CQRS, para tener una mejor mediacion
- para CQRS se utilizo Mediator
  
[![Domain](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_Domain.png "Domain")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_Domain.png "Domain")

- Infraestructure, la capa de datos
- Cabe destacar que para este ejemplo se utilizaron 2 tipos de Infraestructure
- Por un lado CQRS, se pueden ver los Queries
- Por otro lado con DBContext y DependencyInjection
  
[![Infraestructure](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_Infraestructure.png "Infraestructure")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_Infraestructure.png "Infraestructure")

- Una vista completa a la arquitectura de la Api


  [![AllApi](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_All2.png "AllApi")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Api_All2.png "AllApi")

## App Front

- Se desarrollo con ASP MVC Net 6
- Se dividio en capas Core y Domain, para un mayor control

  


[![FrontAll](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Front_All.png "FrontAll")](https://github.com/RobertBonilla/BancoTarjeta/blob/TestDocumentation/Documentacion/capturas/Code/arquitectura_Front_All.png "FrontAll")






















