const Message = require("../models/message.model.js");
const Joi = require("joi");

const messageSchema = Joi.object({
    to: Joi.string().required(),
    from: Joi.string().required(),
    msg: Joi.string().required()
})

module.exports = {
    insert,
    getAll,
    getById
}

async function insert(message) {
    message = await Joi.validate(message, messageSchema);
    return await new Message(message).save();
}

async function getAll() {
    return await Message.find();
};

async function getById(id) {
    return await Message.findById(id);
};
