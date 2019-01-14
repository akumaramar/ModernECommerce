'use strict'

const express = require("express");
const bodyParser = require("body-parser");
const routes = require("../routes/index.route");

// Create express application
const app = express();
app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());

// Bbasic Template route
app.get("/", (req, res) => {
    res.json({"message":"Hello from Express application"});
});

// API router
app.use('/api', routes);

module.exports = app;

