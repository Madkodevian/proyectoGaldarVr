module.exports = app => {
    const vrwalks = require("../controllers/vrwalk.controller.js");

    var router = require("express").Router();

    // Create a new VR walk
    router.post("/", vrwalks.create);

    // Retrieve all VR walks
    router.get("/", vrwalks.findAll);

    // Retrieve a single VR walk with id
    router.get("/:id", vrwalks.findOne);

    // Update a VR walk with id
    router.put("/:id", vrwalks.update);

    // Delete a VR walk with id
    router.delete("/:id", vrwalks.delete);
    
    app.use('/api/vrwalks', router);
};
