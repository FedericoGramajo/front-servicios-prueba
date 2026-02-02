window.aSL = (e, dH) => {
    e.addEventListener('scroll', async () => {
        if (await iSAB(e)) {
            dH.invokeMethodAsync('OSTB');
        }
    });
};

window.iSAB = async (e) => {
    return e.scrollHeight - e.scrollTop === e.clientHeight;
};

window.sSP = (e) => {
    var d = document.getElementById(e.id);
    d.addEventListener('scroll', function () {
        sessionStorage.setItem('sP', d.scrollTop);
    });
};
window.rSP = (e) => {
    var d = document.getElementById(e.id);
    var sP = sessionStorage.getItem('sP');
    if (sP !== null) {
        d.scrollTop = parseInt(sP);
    }
};

