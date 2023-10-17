const { register } = require("./controllers/user");

module.exports = (router) => {
  router.get("/auth/register", register);
};
