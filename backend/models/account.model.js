module.exports = (sequelize, Sequelize) => {
    const Account = sequelize.define("account", {
        activities: {
            type: Sequelize.STRING
        },
        userComment: {
            type: Sequelize.STRING
        }
    });

    return Account;
};