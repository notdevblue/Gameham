const { Rooms } = require("../Utils/Room")

module.exports = {
    type: "start",
    handle(socket, payload) {
        Rooms.startAt(socket.room);
    }
}