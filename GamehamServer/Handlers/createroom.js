const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "createroom",
    handle(socket, payload) {
        const name = JSON.parse(payload).msg;
        
        Rooms.createRoom(socket, name);
    }
}