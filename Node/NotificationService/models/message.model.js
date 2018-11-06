const mongoose = require('mongoose');

const MessageScehma = mongoose.Schema({
    to: String,
    from: String,
    msg: String
},{
    timestamps: true
});

module.exports = mongoose.model('Message', MessageScehma);

