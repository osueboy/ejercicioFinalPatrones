# ejercicioFinalPatrones
ejercicio que combina patrones de diseño

Se creó el patrón cadena de responsabilidad, se encuentra en la clase RangoDeTiempoProvider.
Otro patrón que se puede observar es el decorator, en la clase RecomendacionReporteadorPedidosDecorator,

El primer patrón permite que se agreguen nuevos rangos temporales sin necesidad que cambiar las clases que utilizan la interfaz IRangoDeTiempoProvider,

De igual manera el decorador permite que se use indiferentemente el servicio principal reporteador o el servicio con el decorador de la recomendación de menor costo
