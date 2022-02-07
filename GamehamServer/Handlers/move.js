const { broadcast } = require("../Utils/Broadcast")

module.exports = {
    type: "move",
    handle(socket, payload) {
        broadcast(socket, payload);
    }
}