const express = require("express");
const app = express();
const data = require("./posts");
const PORT = process.env.PORT || 5000;

let posts = [];

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.listen(PORT, () => {
  console.log(`Example app listening on port ${PORT}`);
});
