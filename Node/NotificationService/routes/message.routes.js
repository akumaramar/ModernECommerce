module.exports = (app) => {
    
    const messagesController = require('../controllers/message.controller.js')

    app.post('/message', messagesController.create);

    app.get('/message', messagesController.getall);
    
};