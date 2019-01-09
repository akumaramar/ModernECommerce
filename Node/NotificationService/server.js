const config = require("./config/config");
const express = require("./config/express");
const mongoose = require("./config/mongoose");
//require("./config/mongoose");

mongoose(function() {
    // Turn on the server to listen to requests
    express.listen(config.port, () => {
        console.info(`Server has started on port number ${config.port}`);
    });    
})
