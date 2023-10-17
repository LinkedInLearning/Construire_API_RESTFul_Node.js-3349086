const bcrypt = require("bcrypt");
const User = require("./models/User");

const saltRounds = 10;
const salt = bcrypt.genSaltSync(saltRounds);

module.exports = {
  register(req, res) {
    try {
      const newUser = new User(req.body);
      newUser.hashedPassword = bcrypt.hashSync(req.body.password, salt);
      newUser.save();
      const userObj = newUser.toObject();
      delete userObj.hashedPassword;
      res.json(userObj);
    } catch (e) {
      res.json("Error while registering new account :" + e);
    }
  },
};
