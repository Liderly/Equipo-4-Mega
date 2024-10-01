# Hackathon-mega

## Requisitos
- Docker
- Kubernetes
- Angular CLI: 18.0.6
- Tener conexión a Internet

## Instrucciones para implementar Kubernetes al proyecto

1. Entra a la ruta `.\backend\` y ejecuta este comando `docker build -t hackaton .`.
2. Entra a la ruta `.\backend\kubernetes\` y ejecuta este comando `kubectl apply -f deployment.yaml`.
3. En la misma ruta(`.\backend\kubernetes\`) ejecuta este comando `kubectl apply -f service.yaml`.
4. Modifica el `appsettings.json` con las credenciales de tu Base de datos.
5. Modifica el `environment.ts` con la direccion que va a tener la API `http://localhost:30000/api`.
6. Ejecuta el frontend(npm install, ng serve).

###

> [!NOTE]
  >  No modifiques el `Server=host.docker.internal;` en el archivo `appsettings.json` ya que es para conectarte a tu base de datos local desde kubernetes.
  > 
  >  **Si estas utilizando minikube recuerda iniciarlo `minikube start`.**


> **Ajusta los detalles**: Modifica las secciones según tus necesidades específicas o el entorno en el que estés trabajando.
>
> **Pruebas**: Asegúrate de probar los comandos y ejemplos incluidos en el `README.md` para confirmar que funcionan en tu entorno.

 
Para más información respecto al evento puedes consultar el siguiente [Notion](https://puzzle-basement-211.notion.site/Hackathon-Semillero-de-talento-Mega-a2a776b0c9394b579341b28033e4f18b)
