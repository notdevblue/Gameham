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
            
            console.log(`ROOM ${packet.roomid} READY STATUS`);
            Rooms.rooms[packet.roomid].players.forEach(e => {
                if (e.id == socket.id) return;
                
                console.log(`SOCKET ID ${e.id}: ${e.ready}\r\n`);

                let payload = JSON.stringify({ id: e.id, status: e.ready });
                socket.send(JSON.stringify(new DataVO("ready", payload)));
            });
        } else {
            socket.send(JSON.stringify(new DataVO("error", JSON.stringify({ msg: res }))));
        }

    }
}