const { broadcast } = require("../Utils/Broadcast")

module.exports = {
    type: "levelUp",
    handle(socket, payload) {
        broadcast(socket, payload);
    }
}