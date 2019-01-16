const Message = require("../models/message.model.js");
async function getall() {
    return await Message.find();
}
