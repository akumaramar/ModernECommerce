'use strict'

// This function implements simple middleware to log the request
module.exports = function(){
    return function(req, res, next){
        console.log(req);
        console.log("Request requested");
        next();
    }
}