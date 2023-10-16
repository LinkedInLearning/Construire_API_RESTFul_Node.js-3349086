const express = require("express");
const app = express();
const data = require("./posts");
const PORT = process.env.PORT || 5000;

let posts = [];

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.get("/posts", (req, res) => {
  const data_posts = [...posts, ...data];
  res.send(data_posts);
});

app.post("/posts/create", (req, res) => {
  posts = [...posts, ...data, req.body];
  res.send("new post successfully added");
});

app.listen(PORT, () => {
  console.log(`Example app listening on port ${PORT}`);
});
