const db = require("../models");
const Account = db.accounts;
const Op = db.Sequelize.Op;

// Create and Save a new Account
exports.create = (req, res) => {
    // Validate request
    if (!req.body.activities) {
        res.status(400).send({
            message: "Content can not be empty!"
        });
        return;
    }

    // Create an Account
    const account = {
        activities: req.body.activities,
        userComment: req.body.userComment
    };

    // Save Account in the database
    Account.create(account)
        .then(data => {
            res.send(data);
        })
        .catch(err => {
            res.status(500).send({
                message:
                    err.message || "Some error ocurred while creating the account."
            });
        });
};

// Retrieve all Accounts from the database
exports.findAll = (req, res) => {
    Account.findAll()
        .then(data => {
            res.send(data);
        })
        .catch(err => {
            res.status(500).send({
                message:
                    err.message || "Some error ocurred while retrieving the accounts."
            });
        });
};

// Find a single Account with an id
exports.findOne = (req, res) => {
    const id = req.params.id;

  Account.findByPk(id)
    .then(data => {
      if (data) {
        res.send(data);
      } else {
        res.status(404).send({
          message: `Cannot find the account with id=${id}.`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error retrieving the account with id=" + id
      });
    });
};

// Update an Account by the id in the request
exports.update = (req, res) => {
    const id = req.params.id;

  Account.update(req.body, {
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "The account was updated successfully."
        });
      } else {
        res.send({
          message: `Cannot update the account with id=${id}. Maybe the account was not found or req.body is empty!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error updating the account with id=" + id
      });
    });
};

// Delete an Account with the specified id in the request
exports.delete = (req, res) => {
    const id = req.params.id;

  Account.destroy({
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "The account was deleted successfully!"
        });
      } else {
        res.send({
          message: `Cannot delete the account with id=${id}. Maybe the account was not found!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Could not delete the account with id=" + id
      });
    });
};