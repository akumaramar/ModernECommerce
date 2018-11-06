const express = require("express");
const bodyParser = require("body-parser");

// Database Configuration
const dbConfig = require('./config/database.config');
const mongoose = require('mongoose');

mongoose.Promise = global.Promise;

// Connecting to database
mongoose.connect(dbConfig.url, {
    useNewUrlParser : true
}).then(() => {
    console.log('Connected to database');
}).catch(err => {
    console.log('Got error while connecting to database. Exiting the application');
    console.log(err);
    process.exit();
})


// Create express application
const app = express();

app.use(bodyParser.urlencoded({extended: true}));

app.use(bodyParser.json());

app.get("/", (req, res) => {
    res.json({"message":"Hello to Express application"});
});

// Require Notes routes
var routes = require('./routes/message.routes.js');
routes(app);

app.listen(3000, () => {
    console.log("Server has started");
});


