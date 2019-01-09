'use strict'

// Bring all dependecies
const express = require("express");
const bodyParser = require("body-parser");
//const swagger = require("swagger-node-express");
const methodOverride = require("method-override");
const loggingMiddleware = require("./logging-middleware");


// Database Configuration
const dbConfig = require('./config/database.config');
const mongoose = require('mongoose');

// Create express application
const app = express();
app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());
app.use(loggingMiddleware());




//swagger.setAppHandler(app);


mongoose.Promise = global.Promise;

// Connecting to database to check if connection is working
mongoose.connect(dbConfig.url, {
    useNewUrlParser : true
}).then(() => {
    logWriter('Connected to database');
}).catch(err => {
    logWriter('Got error while connecting to database. Exiting the application');
    logWriter(err);
    process.exit();
})



// Bbasic Template route
app.get("/", (req, res) => {
    res.json({"message":"Hello to Express application"});
});


// Require Notes routes
var routes = require('./routes/message.routes.js');
routes(app);


// Turn on the server to listen to requests
app.listen(3000, () => {
    logWriter("Server has started");
});


function logWriter(err)
{
    console.log(err);
}
