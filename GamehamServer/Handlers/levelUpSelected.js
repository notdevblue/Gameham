const { broadcast } = require("../Utils/Broadcast")

module.exports = {
    type: "levelUpSelected",
    handle(socket, payload) {
        broadcast(socket, payload);
    }
}