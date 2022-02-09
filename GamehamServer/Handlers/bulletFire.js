const { broadcast } = require("../Utils/Broadcast");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "bulletFire",
    handle(socket, payload) {

        broadcast(socket, JSON.stringify(new DataVO("bulletFire", payload)));
    }
}