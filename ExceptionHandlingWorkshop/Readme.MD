# Taller de práctica de manejo de excepciones

Este pequeño proyecto te ayudará a entender cómo funciona el manejo de excepciones en código real 
en C#.

## 1. Haciendo logging de excepciones
En este ejercicio te debes asegurar de que todas las excepciones que se generen en el método 
`SaveListOfusers` de la clase `UserReport` se registren en el log. Para esto puede usar el método
`LogExceptio`n del objeto `_logger`. Debe asegurar que las excepciones que se captures y se agreguen
a log, luego sean arrojadas nuevamente a quien haya invocado el método.

> Para verificar la implementación del ejercicio, ejecuta el caso de prueba `UserReportTestsExcercise1`

## 2. Manejando excepciones de I/O
Ya que el código del método `SaveListOfusers` está escribiendo a un archivo para exportar, puede
fallar si el usuario que ejecuta el código no tiene suficientes permisos.

Debes manejar este caso, adicionando las siguientes reglas:
- Capturar excepciones del tipo `UnauthorizedAccessException`
- Agregar dichas excepciones a log
- Asegurarse de que el método no arroja una excepción, sino que retorna `false` para indicar que no
se pudo llevar a cabo la exportación.

> Para verificar la implementación del ejercicio, ejecuta el caso de prueba `UserReportTestsExcercise2`

## 3. Arropar otras excepciones
Si se arroja una excepción `NullReferenceException` debido a problemas técnicos, la debes capturar y
arroparla en una excepción `InvalidOperationException` con un mensaje de excepción apropiado que indique
que la exportación no se pudo llevar a cabo.

Implementa las siguientes reglas:

- Captura las excepciones del tipo `NullReferenceException`
- Agregar la excepción a log
- Haz que el método arroje una nueva excepción de tipo `InvalidOperationException`
	- La nueva excepción debe tener un mensaje "Could not create the report, check logs for more details"
	- La nueva excepción debe tener una referencia a la excepción capturada

> Para verificar la implementación del ejercicio, ejecuta el caso de prueba `UserReportTestsExcercise3`

## 4. Todo combinado
Antes de subir el código a producción, debes asegurarte que todos los tres casos anteriores
se manejan correctamente al mismo tiempo.

> Para verificar la implementación del ejercicio, ejecuta todos los casos de prueba