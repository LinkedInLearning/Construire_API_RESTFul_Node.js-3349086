## REST API

- **express**: framework web pour créer des application web et des serveurs Node.js
- **nodemon**: utilitaire qui permet de redémarrer automatiquement le serveur à chaque modification des fichiers javascript
- **MongoDB Node.js Driver**: pilote Node.js pour MongoDB
- **mongoDB Compass** [télécharger](https://www.mongodb.com/products/tools/compass): interface graphique pour MongoDB
- **dotenv**: module qui charge les variables d'environnement à partir d'un fichier .env

## Installation :

`npm install`

### MongoDB Node.js Driver [lien](https://www.npmjs.com/package/mongodb)

`npm i mongodb`

### Mongoose [lien](https://mongoosejs.com/)

`npm install mongoose --save`

## Lancer le projet :

`npm start`

## Tester le projet :

### Envoi d'une requête GET à l'URL http://localhost:5000/posts

`curl http://localhost:5000/posts`

### Requête POST à l'URL http://localhost:5000/posts/create

```
curl -X POST \
  http://localhost:5000/posts/create \
  -H 'Content-Type: application/json' \
  -d '{
    "title": "Unlocking the Potential of Remote Learning with Gamification",
    "content": "The landscape of education is changing, and eLearning is at the forefront of this transformation. One of the most exciting trends in eLearning is the use of gamification to enhance the learning experience. Gamification involves the application of game-like elements such as points, badges, and leaderboards into educational settings. This approach has been shown to increase engagement, motivation, and retention among learners. By making the learning process more interactive and rewarding, gamification can help to overcome some of the challenges associated with remote learning, such as lack of focus and engagement. Moreover, it opens up opportunities for real-time feedback and adaptive learning pathways, making education more personalized and effective. As we move towards a more digital future, the integration of gamification in eLearning platforms is not just a trend but a necessity for fostering a dynamic and impactful learning environment.",
    "author": "Jane Smith"
  }'
```

###  Requêtes POST pour créer un utilisateur http://localhost:5000/auth/register

```
curl -X POST \
  http://localhost:5000/auth/register \
  -H 'Content-Type: application/json' \
  -d '{
    "firstName": "Diana",
    "lastName": "L",
    "username": "diana2023",
    "email": "diana2023.com",
    "password": "0./<>@5/#89"
  }'
```

```
curl -X POST \
  http://localhost:5000/auth/register  \
  -H 'Content-Type: application/json' \
  -d '{
    "firstName": "Diana",
    "lastName": "Linares",
    "username": "diana2023",
    "email": "diana2023@gmail.com",
    "password": "0./<>@5/#89"
  }'
```

### Requêtes POST pour connecter un utilisateur http://localhost:5000/auth/login


```
curl -X POST \
  http://localhost:5000/auth/login \
  -H 'Content-Type: application/json' \
  -d '{
    "email": "diana@gmail.com",
    "password": "0./<>@5/#89"
  }'
```

```
curl -X POST \
  http://localhost:5000/auth/login \
  -H 'Content-Type: application/json' \
  -d '{
    "email": "diana2023@gmail.com",
    "password": "test123"
  }'
```
```
curl -X POST \
  http://localhost:5000/auth/login \
  -H 'Content-Type: application/json' \
  -d '{
    "email": "diana2023@gmail.com",
    "password": "0./<>@5/#89"
  }'
```

## Documentation API:

[Documentation sur Postman](https://documenter.getpostman.com/view/19676848/2s9YR84CzK)

