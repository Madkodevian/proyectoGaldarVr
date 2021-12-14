const db = require("../models");
const Vrwalk = db.vrwalks;
const Op = db.Sequelize.Op;

// Create and Save a new VR walk
exports.create = (req, res) => {
    // Validate request
    if (!req.body.scene) {
        res.status(400).send({
            message: "Content can not be empty!"
        });
        return;
    }

    // Create a VR walk
    const vrwalk = {
        scene: req.body.scene,
        information: req.body.information
    };

    // Save VR walk in the database
    Vrwalk.create(vrwalk)
        .then(data => {
            res.send(data);
        })
        .catch(err => {
            res.status(500).send({
                message:
                    err.message || "Some error ocurred while creating the VR walk."
            });
        });
};

// Retrieve all VR walks from the database
exports.findAll = (req, res) => {
    Vrwalk.findAll()
        .then(data => {
            res.send(data);
        })
        .catch(err => {
            res.status(500).send({
                message:
                    err.message || "Some error ocurred while retrieving the VR walks."
            });
        });
};

// Find a single VR walk with an id
exports.findOne = (req, res) => {
    const id = req.params.id;

  Vrwalk.findByPk(id)
    .then(data => {
      if (data) {
        res.send(data);
      } else {
        res.status(404).send({
          message: `Cannot find the VR walk with id=${id}.`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error retrieving the VR walk with id=" + id
      });
    });
};

// Update a VR walk by the id in the request
exports.update = (req, res) => {
    const id = req.params.id;

  Vrwalk.update(req.body, {
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "The VR walk was updated successfully."
        });
      } else {
        res.send({
          message: `Cannot update the VR walk with id=${id}. Maybe the VR walk was not found or req.body is empty!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error updating the VR walk with id=" + id
      });
    });
};

// Delete a VR walk with the specified id in the request
exports.delete = (req, res) => {
    const id = req.params.id;

  Vrwalk.destroy({
    where: { id: id }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "The VR walk was deleted successfully!"
        });
      } else {
        res.send({
          message: `Cannot delete the VR walk with id=${id}. Maybe VR walk was not found!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Could not delete the VR walk with id=" + id
      });
    });
};