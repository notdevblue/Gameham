const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "roomquery",
    handle(socket, payload) {
        Rooms.fetchRoomData(socket);
    }
}