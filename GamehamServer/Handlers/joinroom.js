const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "joinroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        let res = Rooms.joinAt(packet.roomid);
        if (res === "") {
            broadcast(socket, payload);
        } else {
            socket.send(JSON.stringify(new DataVO("error", JSON.stringify({ msg: res }))));
        }

    }
}