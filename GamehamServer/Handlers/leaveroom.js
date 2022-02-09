const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "leaveroom",
    handle(socket, payload) {
        const packet = JSON.parse(payload);
        res = Rooms.leaveAt(socket, packet.roomid);
        let data = JSON.stringify(new DataVO("leaveroom", payload));
        console.log(data);
        
        switch (res)
        {
            case "":
                let payload = JSON.stringify({ id: socket.id, status: false });

                Rooms.rooms[packet.roomid].broadcast(data);
                Rooms.rooms[packet.roomid].broadcast(JSON.stringify(new DataVO("ready", payload)));
                break;
            
            case "-d":
                Rooms.removeRoom(packet.roomid);
                socket.send(data);
                break;
            
            default:
                socket.send(JSON.stringify(new DataVO("error", JSON.stringify({ msg: res }))));
                break;
        }
    }
}