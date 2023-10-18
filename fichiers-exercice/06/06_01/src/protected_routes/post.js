const {
  createPost,
  findOnePostAndUpdate,
  findOnePostAndDelete,
} = require("../controllers/post");

function loginRequired(req, res, next) {
  if (!req.user) {
    res.status(401).json({
      message: "Unauthorized user, Please register a new account or login",
    });
  }
  next();
}

module.exports = (router) => {
  router.post("/posts/create", loginRequired, createPost);
  router.put("/posts/update/:id", loginRequired, findOnePostAndUpdate);
  router.delete("/posts/delete/:id", loginRequired, findOnePostAndDelete);
};
