const express = require('express');
const messagesController = require('../controllers/message.controller.js');
const asynHandler = require('express-async-handler');

const router = express.Router();
module.exports = router;

router.route('/')
    .get(asynHandler(getAll))
    .post(asynHandler(insert))
    .delete(asynHandler(deleteMessage));

router.route('/:id')
    .get(asynHandler(getById));

async function insert(req, res) {
    let message = await messagesController.insert(req.body);
    res.json(message);
}

async function getAll(req, res) {
    let messages = await messagesController.getAll();
    res.json(messages);
}

async function getById(req, res) {
    let messages = await messagesController.getById(req.params.id);
    res.json(messages);
}
/*
async function deleteMessage(req, res) {
    await messagesController.deleteMessage(req.params.id);
    res.
}*/
