### Features

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

  
