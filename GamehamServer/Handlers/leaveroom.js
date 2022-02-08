const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "leaveroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        res = Rooms.leaveAt(socket, packet.roomid);
        if (res == "") {
            let data = JSON.stringify(new DataVO("leaveroom", payload));
            Rooms.rooms[packet.roomid].broadcast(data);
            socket.send(data);
        } else {
            socket.send(JSON.stringify(new DataVO("error", JSON.stringify({ msg: res }))));
        }
    }
}