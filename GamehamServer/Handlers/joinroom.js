const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "joinroom",
    handle(socket, payload) {
        const roomid = JSON.parse(payload).roomid;
        Rooms.joinAt(socket, roomid);
    }
}