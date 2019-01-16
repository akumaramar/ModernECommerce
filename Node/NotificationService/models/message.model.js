const mongoose = require('mongoose');

const MessageScehma = mongoose.Schema({
    to: {
        type: String,
        required: true
    },
    from: {
        type: String,
        required: true
    },
    msg: {
        type: String,
        required: true
    }
},{
    timestamps: true
});

module.exports = mongoose.model('Message', MessageScehma);

