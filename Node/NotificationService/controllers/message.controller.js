const Message = require("../models/message.model.js");

exports.create = (req, res) => {

    if(!req.body) {
        return res.status(400).send({
            message: "Note content can not be empty"
        });
    }

    const message = new Message({
        to: "toAjay",
        from: "fromAjay",
        msg: "Hello Message"
    });

    message.save()
    .then(data => {
        res.send(data);
    }).catch( err => {
        console.log("error while saving the data to database");
        console.log(err);
        res.status(500).send({
            message: err.message || "Some error occurred while creating the Note."
        });
    })

    
};

exports.getall = (req, res) => {

    // Testing error handling methods of the Node Express.
    //throw new Error("Got errpr while calling this function");

    Message.find()
    .then(messages => {
        res.send(messages);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while retrieving notes."
        });
    });

};
