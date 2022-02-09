const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "joinroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        let res = Rooms.joinAt(socket, packet.roomid);
        if (res === "") {
            Rooms.rooms[packet.roomid].broadcast(JSON.stringify(new DataVO("joinroom", payload)));
        } else { // TODO: 방 들어갔을떄 레디 상태
            console.log(res);
            socket.send(JSON.stringify(new DataVO("error", JSON.stringify({ msg: res }))));
        }

    }
}