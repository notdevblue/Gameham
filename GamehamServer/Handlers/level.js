const { broadcast } = require("../Utils/Broadcast")

module.exports = {
    type: "level",
    handle(socket, payload) {
        broadcast(socket, payload);
    }
}