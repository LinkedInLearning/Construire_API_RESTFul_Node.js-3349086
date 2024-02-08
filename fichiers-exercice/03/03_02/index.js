const express = require("express");
const mongoose = require("mongoose");
const app = express();
const data = require("./posts");
const PORT = process.env.PORT || 5000;

app.use(express.json());

let posts = [];

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.get("/posts", (req, res) => {
  const data_posts = [...posts, ...data];
  res.send(data_posts);
});

app.post("/posts/create", (req, res) => {
  posts = [...posts, req.body];
  res.send("new post successfully added");
});

app.listen(PORT, () => {
  console.log(`Example app listening on port ${PORT}`);
  mongoose.connect("mongodb://127.0.0.1:27017/database").then(() => {
    console.log("successfully connected to the database");
  });
});
