const { broadcast } = require("../Utils/Broadcast")

module.exports = {
    type: "bulletFire",
    handle(socket, payload) {
        broadcast(socket, payload);
    }
}