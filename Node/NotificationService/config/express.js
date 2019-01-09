'use strict'

const express = require("express");
const bodyParser = require("body-parser");

// Create express application
const app = express();
app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());

// Bbasic Template route
app.get("/", (req, res) => {
    res.json({"message":"Hello from Express application"});
});


module.exports = app;

