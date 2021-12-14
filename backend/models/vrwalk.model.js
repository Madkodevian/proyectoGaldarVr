module.exports = (sequelize, Sequelize) => {
    const Vrwalk = sequelize.define("vrwalk", {
        scene: {
            type: Sequelize.STRING
        },
        information: {
            type: Sequelize.STRING
        }
    });

    return Vrwalk;
};