const mongoose = require("mongoose");
const config = require("./config");

//connect to MongoDB
// mongodb://mongo:27017/notificationService
const mongoUri = `mongodb://${config.mongo.host}:${config.mongo.port}/${config.mongo.dbName}`;

module.exports = function initConnection(callback) {
    // Connecting to database to check if connection is working
    mongoose.connect(mongoUri, {
        useNewUrlParser : true
    }).then(() => {
        console.log('Connected to database');
        callback();
    }).catch(err => {
        console.log('Got error while connecting to database. Exiting the application');
        console.log(err);
        process.exit();
    })
}

