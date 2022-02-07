const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "roomquery",
    handle(socket, payload) {
        let roomData = [];
        
        Rooms.rooms.forEach(e => {
            roomData.push(JSON.stringify(e));
        });

        broadcast(socket, JSON.stringify(new DataVO("roomquery", JSON.stringify(roomData))));
    }
}