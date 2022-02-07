const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "joinroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        Rooms.leaveAt(packet.roomid);

        broadcast(socket, JSON.stringify(new DataVO("room", JSON.stringify({ type: "leave", roomid: packet.roomid }))));
    }
}