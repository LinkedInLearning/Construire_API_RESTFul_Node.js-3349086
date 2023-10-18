const User = require("../models/User");
const {
  createPost,
  findOnePostAndUpdate,
  findOnePostAndDelete,
} = require("../controllers/post");

const { generateAPIKey } = require("../controllers/user");

function loginRequired(req, res, next) {
  if (!req.user) {
    res.status(401).json({
      message: "Unauthorized user, Please register a new account or login",
    });
  }
  next();
}

function apiKeyRequired(req, res, next) {
  const apiKey = req.header("x-api-key");
  const users = User.find({});
  const account = users.find((user) => user.apiKey === apiKey);

  if (!apiKey || !account) {
    return res.status(403).json({
      code: 403,
      message: "You are not allowed. Register for a new Api key",
    });
  }

  next();
}

module.exports = (router) => {
  router.post("/generateApiKey", loginRequired, generateAPIKey);
  router.post("/posts/create", loginRequired, createPost);
  router.put("/posts/update/:id", loginRequired, findOnePostAndUpdate);
  router.delete("/posts/delete/:id", loginRequired, findOnePostAndDelete);
};
