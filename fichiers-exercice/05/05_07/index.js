const express = require("express");
const mongoose = require("mongoose");
const jwt = require("jsonwebtoken");
const app = express();
const postrouter = express.Router();
const userrouter = express.Router();
const protectedrouter = express.Router();
require("./src/routes/post")(postrouter);
require("./src/routes/user")(userrouter);
require("./src/protected_routes/post")(protectedrouter);
const PORT = process.env.PORT || 5000;

app.use(express.json());

function authorize(req, res, next) {
  console.log(req.headers.authorization.split(" ")[0]);
  if (
    req.headers &&
    req.headers.authorization &&
    req.headers.authorization.split(" ")[0] === "JWT"
  ) {
    jwt.verify(
      req.headers.authorization.split(" ")[1],
      process.env.TOKEN_SECRET,
      function (err, decode) {
        if (err) req.user = undefined;
        req.user = decode;
        next();
      }
    );
  } else {
    req.user = undefined;
    next();
  }
}

app.listen(PORT, () => {
  app.use("/", postrouter);
  app.use("/", userrouter);
  app.use(authorize);
  app.use("/", protectedrouter);
  console.log(`Example app listening on port ${PORT}`);
  mongoose.connect("mongodb://127.0.0.1:27017/database").then(() => {
    console.log("successfully connected to the database");
  });
});
