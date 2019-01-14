const express = require('express');
const messagesController = require('../controllers/message.controller.js')

const router = express.Router();

router.route('/')
    .get(messagesController.getall)
    .post(messagesController.create);
    
module.exports = router;

//router.route('/')
   

/*
module.exports = (app) => {
    
    const messagesController = require('../controllers/message.controller.js')

    app.post('/message', messagesController.create);

    app.get('/message', messagesController.getall);
    
};*/