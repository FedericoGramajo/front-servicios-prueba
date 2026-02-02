function bM(d, r) {
    d.addEventListener("close", async e => {
        await r.invokeMethodAsync("MA", d.returnValue);
    });
}
function bOM(d) {
    if (d && !d.open) {
        d.showModal();
    }
}

function bCM(d) {
    if (d && d.open) {
        d.close();
    }
}

window.sD = function () {
    document.getElementById('cD').showModal();
}
window.cD = function () {
    document.getElementById('cD').close();
}