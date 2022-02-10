const { MonsterSpanwer } = require("../Utils/Monsters");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "MonsterSpanwer",
    handle(socket, payload) {
        
        let m = new MonsterSpanwer(socket);

        m.spawnStart();
    }
};