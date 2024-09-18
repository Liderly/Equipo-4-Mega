### Hackathon equipo 4 DevHeros

## Objetivo
Reunir a personas en equipo para resolver un problema, en este tipo de eventos se puede ver ya sea  presencialmente o virtual, las actitudes y aptitudes de los integrantes.

## Proceso
- Para empezar, antes de las 9:00 nos dierton 15 minutos para escoger y asignar los roles del equipo, comenzamos por preguntarnos entre nosotros qué es lo que nos gustaría hacer, cuáles eran nuestras fortalezas.

Se tenía que elegir un líder de equipo y un documentador, como roles principales. Se escogieron.

Quedamos divididos de la siguiente manera:
- Una persona se encargaría de la creación de la base de datos y llevar la computadora.
- Otra persona se dedicaría a verlo del backend
- Otras dos personas se dedicarían a verlo de el frontend
- Y otra se dedicaría a la docmentación

Pero antes de eso, todos estuvimos analizando el problema y aportando ideas.

Decidimos empezar por el modelado de la base de datos, una vez entendiendo el problema,
Se modeló en equipo y se llegó a un diagra entidad relación como el siguente:
![diagramaEr](images/diagramaER.jpeg)

Esto basado en nuestro análisis que hicimos en el material que nos entregaron para dibujar.
![preDiagrama](images/preDiagrama.jpeg)

## Concluciones del análisis

Se va a generar un dashboard para los encargados de la nómina de mega.
En el que el encargado pueda visualizar con reportes, el monto del bono de ese colaborador

Después de tener el diagrama entidad relacion, ya el encargado de base de datos comenzo a escribir los scripts para crear las tablas en nuestra base de datos.

Tuvimos una pequeña reunión para quedar en claro lo que ibamos a hacer.

El equipo de front comenzó a diseñar las vistas y el equipo de backend comenzó a generar los modelos.

Tenemos este login:
![login](images/login.PNG)

Esta es la vista principal donde se ve una lista de todos los tecnicos.
![vistaListaTecnicos](images/vistaTodosTecnicos.jpeg)

Al seleccionar el técnico se va a la vista de detalles y allí se verán los datos de los tecnicos y el calculo de bono por cada una de sus ordenes de trabajo.
![vistaTecnicos](images/vistaTecnicos.jpeg)

Además de que al final se muestra el cálculo gobalizado por todas las ordenes de trabajo
![vistaCalculo](images/vistaCalculo.jpeg)


## Proyeccion a futuro

Se podría agregar la funcionalidad de crud para modificar los datos de las ordenes

Tambien se podría implementar el envío automatico de los bonos tanto a los tecnicos como los jefes que ven la parte de la nomina.

Cálculo semanal automatico.