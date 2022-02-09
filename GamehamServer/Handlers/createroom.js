const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "createroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        
        let roomid = Rooms.createRoom(packet.msg);
        
        if (roomid * 2 == undefined) {
            socket.send(JSON.stringify(new DataVO("error", JSOn.stringify({ msg: roomid }))));
            return;
        }

        let res = Rooms.joinAt(socket, roomid);

        if (res === "") {
            let response = JSON.stringify({ roomid: roomid, id: socket.id });
            socket.send(JSON.stringify(new DataVO("joinroom", response)));
        } else {
            console.log(res);
            socket.send(JSON.stringify(new DataVO("error", JSON.stringify({ msg: res }))));
        }

    }
}