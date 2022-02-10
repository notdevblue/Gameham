const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "leaveroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        Rooms.leaveAt(socket.room);
    }
}