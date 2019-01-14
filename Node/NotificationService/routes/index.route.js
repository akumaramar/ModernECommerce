const express = require('express');
const messageRoutes = require("./message.routes");

const router = express.Router();

router.get('/health-check', (req, res) => {
    res.send('OK');
});

router.use('/message', messageRoutes);

module.exports = router;